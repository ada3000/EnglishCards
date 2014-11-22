using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Assets.Scripts.Data;
using Assets.Scripts.Common;

namespace AnkiToDictConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cbSelectSource_Click(object sender, EventArgs e)
        {
            if(OFD.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                txtSource.Text = OFD.FileName;
                txtDest.Text = txtSource.Text + ".dict";
            }
        }

        private void cbConvert_Click(object sender, EventArgs e)
        {
            try
            {
                int res = DoConvert(txtSource.Text, txtDest.Text);
                MessageBox.Show("Successeful converted " + res + " items!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Conver error");
            }
        }

        private int DoConvert(string sourceFile, string destFile)
        {
            string source = File.ReadAllText(sourceFile);

            string[] lines = source.Split('\n');

            SystemDictionary dict = new SystemDictionary();

            dict.Id="АДА";

            foreach(string line in lines)
            {
                string[] parts = line.Split('\t');
                if (parts.Length < 2)
                    continue;

                Word w = new Word { TextEn = parts[0], TextRu = parts[1] };
                dict.Add(w);
            }

            string jsonData = (dict as ISimpleJsonSerializable).ToJsonString();

            File.WriteAllText(destFile, jsonData);

            return dict.Count;
        }
    }
}
