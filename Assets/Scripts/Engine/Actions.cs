using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Scripts.Common;
using Assets.Scripts.Data;

using UnityEngine;

namespace Assets.Scripts.Engine
{
    public class Actions : Script
    {
        private static Actions _instance = null;
        private static object _lock = new object();

        private ViewManager _viewManager;

        #region Init

        private Actions()
        {
            
        }

        public static Actions Instance
        {
            get
            {
                return _instance ?? (_instance = CreateInstance());
            }
        }

        private static Actions CreateInstance()
        {
            lock(_lock)
            {
                Actions inst = new Actions();                
                InitInstance(inst);

                return inst;
            }
        }

        private static void InitInstance(Actions inst)
        {
            inst._viewManager = FindObjectOfType<ViewManager>();
        }

        #endregion

        public void EditDictionary(WordDictionary dict)
        {
            _viewManager.EditDictionary.SelectDictionary(dict);
            _viewManager.EditDictionary.Show();
        }

        public void LearnDictionary(WordDictionary dict)
        {
            _viewManager.Learn.SelectDictionary(dict);
            _viewManager.Learn.Show();
        }
    }
}
