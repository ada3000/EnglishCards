using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Scripts.Common;
using Assets.Scripts.Engine;

using UnityEngine;

namespace Assets.Scripts.Views
{
    public class ViewBase: MonoBehaviour
    {
        public event Action<ViewBase> ShowEnd = (v) => { };

        public event Action<ViewBase> GotoBackUp = (v) => { };

        public GameObject Container;
        public GameButton BackButton;

        public virtual void Awake()
        {
            if (BackButton != null)
                BackButton.Up += BackButton_Up;
        }

        void BackButton_Up()
        {
            GotoBackUp(this);
        }

        public bool IsVisible
        {
            get
            {
                return Container.activeSelf;
            }
        }
        public void Show()
        {
            if (IsVisible) return;
            Container.SetActive(true);

            ShowEnd(this);
        }
        public void Hide()
        {
            if (!IsVisible) return;
            Container.SetActive(false);
        }
    }
}
