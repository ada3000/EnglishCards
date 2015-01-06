using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Scripts.Common;
using Assets.Scripts.Engine;

using UnityEngine;

namespace Assets.Scripts.Behaviors
{
    public class DictionaryNodeBehavior: Script
    {
        public GameObject Node;

        public GameButton Button;
        public GameButton RemoveButton;
        public UILabel Label;
        public GameObject CheckedNode;

        public void Awake() // Test asteroid
        {
            Button.Up += Button_Up;
            RemoveButton.Up += RemoveButton_Up;
        }

        void RemoveButton_Up()
        {
            FindObjectOfType<DictionaryManager>().Remove(this);
        }

        void Button_Up()
        {
            Checked = true;
        }

        public bool Checked
        {
            get
            {
                return CheckedNode.activeSelf;
            }
            set
            {
                if (value)
                {
                    var parent = Node.GetComponentInParent<UIPanel>();
                    foreach (var n in parent.GetComponentsInChildren<DictionaryNodeBehavior>())
                        n.Checked = false;
                }

                CheckedNode.SetActive(value);
                RemoveButton.gameObject.SetActive(value);
            }
        }
    }
}
