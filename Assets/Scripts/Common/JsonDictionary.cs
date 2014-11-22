using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Scripts.Common;

using SimpleJSON;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Словарь - источник слов
    /// </summary>
    public class JsonDictionary<TValue> : Dictionary<string, TValue>, IJsonSs where TValue : IJsonSs, new()
    {
        public void SetData(JSONNode node)
        {
            Clear();

            JSONArray items = node["items"].AsArray;
            if(items!=null)
                foreach(JSONNode i in items)
                {
                    TValue value = new TValue();
                    (value as IJsonSs).SetData(i["v"]);

                    string key = i["k"].Value;
                    Add(key, value);
                }
        }

        public JSONClass GetData()
        {
            JSONClass node = new JSONClass();
            
            JSONArray items = (node["items"] = new JSONArray()).AsArray;

            foreach (string key in Keys)
            {
                TValue value = this[key];
                JSONClass jsonValue = (value as IJsonSs).GetData();
                JSONClass rowNode = new JSONClass();
                rowNode["k"] = key;
                rowNode["v"] = jsonValue;
                items[-1] = rowNode;
            }

            return node;
        }
    }
}
