using System;
using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Engine
{
    public class Engine : Script
    {
        public void Awake()
        {
			Actions.Instance.LearnDictionary (null);
//var res = Resources.Load("Dictionaries/test", typeof(string));
            //Debug.Log(res);
            
            //SimpleJSON.JSONClass node = new SimpleJSON.JSONClass();
            //node["id"] = "Тостер выпил пива";

            //Debug.Log(node.ToJsonString());

            //GetComponent<AsteroidView>().Open();
        }

        public void OnApplicationPause(bool paused)
        {
            Profile.Instance.Save();
            Debug.Log("OnApplicationPause");
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
                Debug.Log("Exit");
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Profile.Instance.Save();
                Debug.Log("Save profile");
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                Profile.Load();
                Debug.Log("Load profile");                
            }
        }
    }
}