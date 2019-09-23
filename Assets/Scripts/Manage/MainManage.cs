using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ELGame
{
    //主要管理者，管理所有管理者
    public class MainManage : ELBehaviour
    {
        private GameObject _MapObject;
        private GameObject _BattleObject;

        public void CreatGame(GameObject Grid)
        {
            GameObject MapObject = GameObject.Find("MapObject");
            GameObject BattleObject = GameObject.Find("BattleObject");
            GameObject MainCamera = GameObject.Find("Main Camera");

            MapManage Map = MapObject.AddComponent<MapManage>();
            EventManage Event = gameObject.AddComponent<EventManage>();
            Map.CreateMap(Grid);


            Vector3 initPos = new Vector3((float) (Map.Row * 15.5 / 2.0), (float) (Map.Column * 14 / 2.0), -100);
            MainCamera.transform.position = initPos;
            Quaternion initRot = new Quaternion(0, 0, 0, 0);
            MainCamera.transform.rotation = initRot;

            //地图对象节点
            _MapObject = MapObject;
            //战斗对象节点
            _BattleObject = BattleObject;
        }
      

        private void OnGUI()
        {
            if (GUI.Button(new Rect(0, 0, 100, 50), "Next"))
            {
            }
        }
    }
}