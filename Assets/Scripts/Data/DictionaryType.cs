using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Scripts.Common;

namespace Assets.Scripts.Data
{
    public class DictionaryType: IJsonSs
    {
        public string FileName;
        public string Desc;

        void IJsonSs.SetData(SimpleJSON.JSONNode node)
        {
            FileName = node["fileName"].Value;
            Desc = node["desc"].Value;
        }

        SimpleJSON.JSONClass IJsonSs.GetData()
        {
            SimpleJSON.JSONClass result = new SimpleJSON.JSONClass();

            result["fileName"] = FileName;
            result["desc"] = Desc;

            return result;
        }
    }
}
