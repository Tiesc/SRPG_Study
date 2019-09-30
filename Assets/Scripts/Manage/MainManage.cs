using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ELGame
{
    //主要管理者，管理所有管理者
    public class MainManage : BaseManager<MainManage>
    {
        private GameObject _scriptsObject;
        private GameObject _cameraObject;
        private GameObject _mapObject;
        private GameObject _battleObject;

//        private GameObject _mainCamera;

        public override void InitManager()
        {
            base.InitManager();

            GameObject mapObject = GameObject.Find("MapObject");
            GameObject scriptsObject = GameObject.Find("ScriptsObject");
            GameObject battleObject = GameObject.Find("BattleObject");
            GameObject cameraObject = GameObject.Find("CameraObject");
//            GameObject mainCamera = GameObject.Find("Main Camera");

            mapObject.AddComponent<MapManage>();
            scriptsObject.AddComponent<EventManage>();
            scriptsObject.AddComponent<SelectTileEvent>();

            EventManage.Instance.InitManager();
            MapManage.Instance.InitManager();

            //脚本对象节点
            _scriptsObject = scriptsObject;
            //相机对象节点
            _cameraObject = cameraObject;
            //地图对象节点
            _mapObject = mapObject;
            //战斗对象节点
            _battleObject = battleObject;
        }

        public void CreatGame(GameObject Grid)
        {
            EventManage.Instance.AddEvent(SelectTileEvent.Instance.HandleInput);
            MapManage.Instance.CreateMap(Grid);

            Vector3 initPos = new Vector3((float) (MapManage.Instance.Row * 15.5 / 2.0),
                (float) (MapManage.Instance.Column * 14 / 2.0), -100);
            _cameraObject.transform.position = initPos;
            Quaternion initRot = new Quaternion(0, 0, 0, 0);
            _cameraObject.transform.rotation = initRot;
        }
    }
}