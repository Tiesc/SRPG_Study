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
//        private GameObject _battleObject;

//        private GameObject _mainCamera;

        public override void InitManager()
        {
            base.InitManager();

            GameObject mapObject = GameObject.Find("MapObject");
            GameObject scriptsObject = GameObject.Find("ScriptsObject");
//            GameObject battleObject = GameObject.Find("BattleObject");
            GameObject cameraObject = GameObject.Find("CameraObject");
//            GameObject mainCamera = GameObject.Find("Main Camera");

            mapObject.AddComponent<MapManage>();
            scriptsObject.AddComponent<EventManage>();
            scriptsObject.AddComponent<SelectTileEvent>();

            EventManage.Instance.InitManager();
            MapManage.Instance.InitManager(mapObject);


            //脚本对象节点
            _scriptsObject = scriptsObject;
            //相机对象节点
            _cameraObject = cameraObject;
            //地图对象节点
            _mapObject = mapObject;
            //战斗对象节点
//            _battleObject = battleObject;
        }

        public void CreatGame(GameObject Grid)
        {
            //todo 先创建好游戏数据之后将数据放到对应的Manger对象上
            EventManage.Instance.Register("test", "listener", SelectTileEvent.Instance.HandleInput);
            if (MapManage.Instance.CreateMapData())
                MapManage.Instance.CreateMapSence(Grid);

            Vector3 initPos = new Vector3((float) (MapManage.Instance.Row * 15.5 / 2.0),
                (float) (MapManage.Instance.Column * 14 / 2.0), -100);
            _cameraObject.transform.position = initPos;
            Quaternion initRot = new Quaternion(0, 0, 0, 0);
            _cameraObject.transform.rotation = initRot;
        }

        public void Update()
        {
            ELGame.IGameEvent Idonknow = null;
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("这东西有点狗啊！！！我没搞明白就可以用了？？？");
                EventManage.Instance.Run("test", Idonknow);
            }
        }
    }
}