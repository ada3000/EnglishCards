using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SimpleJSON;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Json Simple Serializable Interface
    /// </summary>
    public interface IJsonSs
    {
        void SetData(JSONNode node);
        JSONClass GetData();
    }
}
