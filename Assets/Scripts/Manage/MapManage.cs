using UnityEngine;

namespace ELGame
{
    public class MapManage : ELBehaviour
    {
        private int _Row = 10;
        private int _Column = 10;

        public void CreateMap(GameObject gameObject)
        {
            CreatGridData CreateMap = new CreatGridData();
            CreateMap.CreateData(_Row, _Column);
            CreateMap.CreateObstacleData(10, 2);
            CreateMap.drawMap(gameObject);
        }
    }
}