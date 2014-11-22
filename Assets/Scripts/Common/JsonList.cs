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
    public class JsonList<TValue> : List<TValue>, IJsonSs where TValue : IJsonSs, new()
    {
        public void SetData(JSONNode node)
        {
            Clear();

            JSONArray items = node["items"].AsArray;
            if(items!=null)
                foreach(JSONNode i in items)
                {
                    TValue value = new TValue();
                    (value as IJsonSs).SetData(i);
                    Add(value);
                }
        }

        public JSONClass GetData()
        {
            JSONClass node = new JSONClass();
            
            JSONArray items = (node["items"] = new JSONArray()).AsArray;

            foreach (TValue value in this)
            {
                JSONClass jsonValue = (value as IJsonSs).GetData();
                items[-1] = jsonValue;
            }

            return node;
        }
    }
}
