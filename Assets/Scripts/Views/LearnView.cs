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
    public class LearnView : ViewBase
    {
        public GameObject ItemsNode;
        public GameButton AddButton;

        public override void Awake()
        {
            base.Awake();

            ShowEnd += LearnView_ShowEnd;
            AddButton.Up += AddButton_Up;

            //ClearNodes();

            Debug.Log("LearnView::Awake");
        }

        private void ClearNodes()
        {
            foreach (var n in ItemsNode.GetComponentsInChildren<DictionaryNodeBehavior>())
            {
                n.gameObject.SetActive(false);
                GameObject.DestroyObject(n);
            }
        }
        void LearnView_ShowEnd(ViewBase obj)
        {
            ClearNodes();

            foreach (string key in Profile.Instance.Dictionaries.Keys)
                RenderDict(key, Profile.Instance.Dictionaries[key]);

            Debug.Log("LearnView::ShowEnd");
        }

        public void AddButton_Up()
        {
            WordDictionary dict = new WordDictionary { Name = "new dict 0" };
            string id = Guid.NewGuid().ToString();

            Profile.Instance.Dictionaries.Add(id, dict);

            RenderDict(id, dict);
        }

        private void RenderDict(string dictId, WordDictionary dict)
        {
            float minY = ItemsNode.transform.localPosition.y;

            //Debug.Log("up minY=" + minY);

            foreach (var n in ItemsNode.GetComponentsInChildren<DictionaryNodeBehavior>())
                if (n.gameObject.activeSelf && n.transform.localPosition.y < minY)
                    minY = n.transform.localPosition.y - 100;

            var node = PrefabsHelper.InstantiateDictionaryNode(ItemsNode.transform);

            var item = node.GetComponent<DictionaryNodeBehavior>();
            item.Label.text = dict.Name;
            item.DictionaryId = dictId;

            minY -= 10;

            Debug.Log("up minY=" + minY);

            node.transform.localPosition = new Vector3(0, minY);

            //Debug.Log("up parent" + ItemsNode.transform);
        }

        public void Remove(DictionaryNodeBehavior node)
        {
            float minY = node.Node.transform.localPosition.y;

            Debug.Log("Remove minY=" + minY);

            GameObject.DestroyImmediate(node.Node);

            List<DictionaryNodeBehavior> nodesToMoveUp = new List<DictionaryNodeBehavior>();

            foreach (var n in ItemsNode.GetComponentsInChildren<DictionaryNodeBehavior>())
                if (n.gameObject.activeSelf && n.transform.localPosition.y < minY)
                    nodesToMoveUp.Add(n);

            Debug.Log("Remove nodesToMoveUp.Count=" + nodesToMoveUp.Count);

            foreach (var n in nodesToMoveUp)
                TweenPosition.Begin(n.Node, 0.3f, new Vector3(n.Node.transform.localPosition.x, n.Node.transform.localPosition.y + 110));

            Debug.Log("Remove");
        }

        public void SelectDictionary(WordDictionary dict)
        {

        }
    }
}
