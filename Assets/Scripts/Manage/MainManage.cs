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
            MapManage Map = MapObject.AddComponent<MapManage>();
            Map.CreateMap(Grid);

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