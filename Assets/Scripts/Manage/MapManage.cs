using System;
using System.Collections.Generic;
using UnityEngine;

namespace ELGame
{
    public class MapManage : BaseManager<MapManage>
    {
        private static int _Row = 15;
        private static int _Column = 10;

        [SerializeField] private GameObject _mapObject;
        [SerializeField] private GameObject _map;
        [SerializeField] private GameObject _gridObject;

        private List<Vector3> _Tile = new List<Vector3>();
        private List<Vector3> _Obstruct = new List<Vector3>();
        private List<Vector3> _MapNum = new List<Vector3>();

        //生成地图的数量
        public static int MapNum = 1;

        public int Row { get; } = _Row;
        public int Column { get; } = _Column;

        public void InitManager(GameObject gameObject)
        {
            base.InitManager();
            GameObject mapGameObject = new GameObject("Map");
            GameObject gridObject = new GameObject("GridObject");
            GameObject battleObject = new GameObject("BattleObject");
            mapGameObject.transform.parent = gameObject.transform;
            gridObject.transform.parent = mapGameObject.transform;
            battleObject.transform.parent = mapGameObject.transform;

            gameObject.AddComponent<CreateGrid>();
            //挂地图信息的脚本
            _mapObject = gameObject;
            _map = mapGameObject;
            _gridObject = gridObject;
        }

        //地图的创建，根据地图的数量创建地图
        public bool CreateMapData()
        {
            CreateMapData CreateMap = new CreateMapData();
            _Tile = CreateMap.CreateData(_Row, _Column);
            if (_Tile == null)
            {
                Debug.Log("战斗地图的地图没有生成=====================>检查地图信息");
                return false;
            }

            _Obstruct = CreateMap.CreateObstacleData(10, 2);
            if (_Obstruct == null)
            {
                Debug.Log("战斗地图的地图的障碍地形没有生成=====================>检查障碍物信息");
                return false;
            }

            return true;
        }

        public void CreateMapSence(GameObject gameObject)
        {
            CreateGrid.Instance.Create(_Tile, _Obstruct, gameObject, _gridObject);
        }

        public int getMapSize()
        {
            return _Row * _Column;
        }
    }
}