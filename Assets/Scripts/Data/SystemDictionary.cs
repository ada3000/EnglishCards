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
    public class SystemDictionary : JsonDictionary<Word>, IJsonSs
    {
        public string Id;
        public void Add(Word word)
        {
            Add(word.Id, word);
        }

        void IJsonSs.SetData(JSONNode node)
        {
            base.SetData(node);

            Id = node.GetString("id");
        }

        JSONClass IJsonSs.GetData()
        {
            JSONClass node = base.GetData();

            node["id"] = Id;

            return node;
        }
    }
}
