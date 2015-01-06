using System.Collections.Generic;

using Assets.Scripts.Common;
using UnityEngine;
using Assets.Scripts.Behaviors;

namespace Assets.Scripts.Engine
{
    public class DictionaryManager : Script
    {
        public GameObject ItemsNode;
        public GameButton AddButton;

        public void Awake()
        {
            AddButton.Up += AddButton_Up;

            foreach (var n in ItemsNode.GetComponentsInChildren<DictionaryNodeBehavior>())
            {
                n.gameObject.SetActive(false);
                GameObject.DestroyObject(n);
            }
        }

        void AddButton_Up()
        {
            float minY = ItemsNode.transform.localPosition.y;

            Debug.Log("up minY=" + minY);

            foreach (var n in ItemsNode.GetComponentsInChildren<DictionaryNodeBehavior>())
                if (n.gameObject.activeSelf && n.transform.localPosition.y < minY)
                    minY = n.transform.localPosition.y - 100;

            var node = PrefabsHelper.InstantiateDictionaryNode(ItemsNode.transform);
            
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
                TweenPosition.Begin(n.Node, 0.3f ,new Vector3(n.Node.transform.localPosition.x, n.Node.transform.localPosition.y + 110));

            Debug.Log("Remove");
        }
    }
}