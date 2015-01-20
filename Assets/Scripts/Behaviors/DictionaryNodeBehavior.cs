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
        public GameButton EditButton;
        public UILabel Label;
        public GameObject CheckedNode;

        public bool AllowEdit = true;

        public string DictionaryId { get; set; }

        public void Awake() // Test asteroid
        {
            Button.Up += Button_Up;
            EditButton.Up += EditButton_Up;
        }

        void EditButton_Up()
        {
            Actions.Instance.EditDictionary(Profile.Instance.Dictionaries[DictionaryId]);
            //FindObjectOfType<DictionaryManager>().Remove(this);
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
                if (!AllowEdit) return;

                if (value)
                {
                    var parent = Node.GetComponentInParent<UIPanel>();
                    foreach (var n in parent.GetComponentsInChildren<DictionaryNodeBehavior>())
                        n.Checked = false;

                    Debug.Log("Activate dict node Name=" + Label.text);
                }

                CheckedNode.SetActive(value);
                EditButton.gameObject.SetActive(value);
            }
        }
    }
}
