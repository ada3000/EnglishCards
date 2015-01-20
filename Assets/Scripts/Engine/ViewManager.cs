using System;
using Assets.Scripts.Views;
using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Engine
{
    public class ViewManager : Script
    {
        public LearnView Learn { get; private set; }
        public EditDictionaryView EditDictionary { get; private set; }

        public Views.ViewBase ActiveView
        {
            get;
            private set;
        }

        public void Awake()
        {
            Learn = FindObjectOfType<LearnView>();
            EditDictionary = FindObjectOfType<EditDictionaryView>();

            Learn.ShowEnd += View_ShowEnd;
            EditDictionary.ShowEnd += View_ShowEnd;
        }

        void View_ShowEnd(Views.ViewBase obj)
        {
            if (ActiveView != null)
                ActiveView.Hide();

            ActiveView = obj;
        }
    }
}