using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Scripts.Common;

namespace Assets.Scripts.Data
{
    public class Word : IJsonSs
    {
        public string Id
        {
            get
            {
                return TextEn.Replace(" ", "");
            }
        }
        public string TextRu;
        public string TextEn;
        public string Transcription;
        public string Description;



        void IJsonSs.SetData(SimpleJSON.JSONNode node)
        {
            TextRu = node.GetString("textRu");
            TextEn = node.GetString("textEn");
            Transcription = node.GetString("transcription");
            Description = node.GetString("description");
        }

        SimpleJSON.JSONClass IJsonSs.GetData()
        {
            SimpleJSON.JSONClass node = new SimpleJSON.JSONClass();

            node["textRu"] = TextRu;
            node["textEn"] = TextEn;
            node["transcription"] = Transcription;
            node["description"] = Description;

            return node;
        }
    }
}
