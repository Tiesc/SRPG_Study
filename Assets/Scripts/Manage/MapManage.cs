using UnityEngine;

namespace ELGame
{
    public class MapManage : BaseManager<MapManage>
    {
        private static int _Row = 15;
        private static int _Column = 10;

        public int Row { get; } = _Row;
        public int Column { get; } = _Column;

        public override void InitManager()
        {
        }

        public void CreateMap(GameObject gameObject)
        {
            CreatGridData CreateMap = new CreatGridData();
            CreateMap.CreateData(_Row, _Column);
            CreateMap.CreateObstacleData(10, 2);
            CreateMap.drawMap(gameObject);
        }

        public int getMapSize()
        {
            return _Row * _Column;
        }
    }
}