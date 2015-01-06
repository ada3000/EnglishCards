using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

using UnityEngine;

using SimpleJSON;

namespace Assets.Scripts.Common
{
    public static class SimpleJsonHelper
    {
        public static string GetString(this SimpleJSON.JSONNode node, string key, string defValue)
        {
            if (node == null || node[key] == null)
                return defValue;

            return node[key].Value;
        }
		public static string GetString(this SimpleJSON.JSONNode node, string key)
		{
			return node.GetString (key, null);
		}
        public static int GetInt(this SimpleJSON.JSONNode node, string key, int defValue)
        {
            if (node == null || node[key] == null)
                return defValue;

            return node[key].AsInt;
        }

		public static int GetInt(this SimpleJSON.JSONNode node, string key)
		{
			return node.GetInt (key, 0);
		}

        public static long GetLong(this SimpleJSON.JSONNode node, string key, long defValue)
        {
            if (node == null || node[key] == null)
                return defValue;

            return long.Parse(node[key].Value);
        }

        public static long GetLong(this SimpleJSON.JSONNode node, string key)
		{
            return node.GetLong(key, 0);
		}

        public static string ToJsonString(this IJsonSs obj)
        {
            if (obj == null) return null;

            return obj.GetData().ToJsonString();
        }

        public static string ToJsonString(this JSONClass obj)
        {
            if (obj == null) return null;

            return obj.ToString();
        }
        public static string ToJsonString<T>(this IEnumerable<T> items)
        {
            if (items == null) return null;
            JSONArray result = new JSONArray();

            foreach(var i in items)
            {
                if (i is IJsonSs)
                    result[-1] = (i as IJsonSs).GetData();
                 else if (typeof(T) == typeof(JSONNode))
                    result[-1] = i  as JSONNode;
                else
                    result[-1] = i.ToString();
            }

            return result.ToString();
        }

        public static T DeserializeJson<T>(this string jsonText) where T : IJsonSs, new()
        {
            if (jsonText == null) return default(T);

            JSONNode node = JSON.Parse(jsonText);

            return node.DeserializeJson<T>();
        }
        public static T DeserializeJson<T>(this JSONNode node) where T : IJsonSs, new()
        {
            if (node == null) return default(T);

            T result = new T();
            (result as IJsonSs).SetData(node);

            return result;
        }

        public static IJsonSs AsIJsonSs(this object obj)
        {
            return obj as IJsonSs;
        }
    }
}
