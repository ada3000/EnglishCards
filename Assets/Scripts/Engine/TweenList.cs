using System;
using UnityEngine;

namespace Assets.Scripts.Engine
{
    public class TweenList : Script
    {
        public GameObject Container;

        private UIPanel Panel;

        private bool _pressed;
        private Vector3 _position;
        private Vector3 _p;

        public void Awake()
        {
            Panel = GetComponent<UIPanel>();
        }
        public void Update()
        {
            //var scroll = Input.GetAxis("Mouse ScrollWheel");

            //if (Math.Abs(scroll) > 0.001)
            //{
            //    const float min = 0.5f;
            //    const int max = 2;
            //    const float speed = 10;
            //    var scale = Mathf.Max(min, Map.transform.localScale.x + scroll * speed);

            //    scale = Mathf.Min(max, scale);

            //    var animationCurve = Map.GetComponent<TweenScale>().animationCurve;

            //    TweenScale.Begin(Map, 0.25f, scale * Vector3.one).animationCurve = animationCurve;
            //}

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _pressed = true;
                _position = 500*Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _p = Container.transform.localPosition;
                //TweenPosition.Begin(Map, 0.25f, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            } 
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _pressed = false;
            }
            else if (_pressed && Input.GetKey(KeyCode.Mouse0))
            {
                var mousePos = 500* Camera.main.ScreenToWorldPoint(Input.mousePosition);// 500*Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log("Mouse posRaw=" + Input.mousePosition);
                Debug.Log("Mouse posWld=" + Camera.main.ScreenToWorldPoint(Input.mousePosition));
                float newY = _p.y + mousePos.y - _position.y;
                if (newY < 0) newY = 0;
                //else
                //{
                //    var items = Container.GetComponentsInChildren(typeof(GameObject), false);
                //    float minY = 0;
                //    foreach (var i in items)
                //        if (i.transform.localPosition.y < minY)
                //            minY = i.transform.localPosition.y;

                //    if (newY > -minY + 100)
                //        newY = -minY + 100;
                //}

                //Container.transform.localPosition = _p + 500 * (Camera.main.ScreenToWorldPoint(Input.mousePosition) - _position);
                Container.transform.localPosition = new Vector3(Container.transform.localPosition.x, newY, Container.transform.localPosition.z);
            }
        }

        //public void Set(Vector2 position, float scale)
        //{
        //    Map.transform.localPosition = new Vector3(position.x, position.y, -1);
        //    Map.transform.localScale = scale * Vector2.one;
        //}
    }
}