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
    public class WordDictionary : JsonDictionary<Word>, IJsonSs
    {
        public string Name;
        public void Add(Word word)
        {
            Add(word.Id, word);
        }

        void IJsonSs.SetData(JSONNode node)
        {
            base.SetData(node);
            Name = node.GetString("name");
        }

        JSONClass IJsonSs.GetData()
        {
            JSONClass node = base.GetData();

            node["name"] = Name;

            return node;
        }
    }
}
