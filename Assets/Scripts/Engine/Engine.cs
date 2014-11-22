using System;
using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Engine
{
    public class Engine : Script
    {
        //public void Awake()
        //{
        //    Env.Initialize();
        //    SelectManager.SelectSystem(Env.SystemNames.Andromeda);
        //    GetComponent<GalaxyView>().Open();
        //}

        public void Awake() // Test asteroid
        {
            var res = Resources.Load("Dictionaries/test", typeof(string));
            Debug.Log(res);
            //Env.Initialize();

            SimpleJSON.JSONClass node = new SimpleJSON.JSONClass();
            node["id"] = "Тостер выпил пива";

            Debug.Log(node.ToJsonString());

            ////SelectManager.SelectShip(0);
            //SelectManager.SelectSystem(Env.SystemNames.Andromeda);
            //SelectManager.SelectLocation(Env.Systems[Env.SystemNames.Andromeda][Assets.Scripts.Environment.AndromedaSystem.Andromeda.A100200.Name]);
            //GetComponent<AsteroidView>().Open();
        }

        //public void Awake() // Test hangar
        //{
        //    Env.Initialize();

        //    GetComponent<SelectManager>().SelectSystem(SystemId.Andromeda);
        //    GetComponent<SelectManager>().SelectLocation(Env.Systems[SystemId.Andromeda][LocationId.Netune]);
        //    GetComponent<HangarView>().Open();
        //}

        public void Update()
        {
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