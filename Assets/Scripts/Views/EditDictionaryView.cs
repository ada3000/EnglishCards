using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Scripts.Behaviors;
using Assets.Scripts.Data;
using Assets.Scripts.Common;
using Assets.Scripts.Engine;

using UnityEngine;

namespace Assets.Scripts.Views
{
    public class EditDictionaryView : ViewBase
    {
        public override void Awake()
        {
            base.Awake();

            GotoBackUp += EditDictionaryView_GotoBackUp;
        }

        void EditDictionaryView_GotoBackUp(ViewBase obj)
        {
            Actions.Instance.LearnDictionary(null);
        }
        public DictionaryNodeBehavior Title;
        public void SelectDictionary(WordDictionary dict)
        {
            Title.Label.text = dict == null ? "null" : dict.Name;
        }
    }
}
