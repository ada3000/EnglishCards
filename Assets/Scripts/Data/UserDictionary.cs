using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Scripts.Common;

using SimpleJSON;

namespace Assets.Scripts.Data
{
    /// <summary>
    /// Словарь - источник слов
    /// </summary>
    public class UserDictionary : SystemDictionary, IJsonSs
    {
        public string Name;
        public JsonList<DictionaryType> BaseDictionaries;

        void IJsonSs.SetData(JSONNode node)
        {
            base.SetData(node);

            Name = node.GetString("name");
            BaseDictionaries = node["baseDictionaries"].DeserializeJson<JsonList<DictionaryType>>();
        }

        JSONClass IJsonSs.GetData()
        {
            JSONClass node = base.GetData();

            node["name"] = Name;

            node["baseDictionaries"] = BaseDictionaries.AsIJsonSs().GetData();

            return node;
        }
    }
}
