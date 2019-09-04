using UnityEngine;

namespace ELGame
{
    public class MapManage : ELBehaviour
    {
        public void CreateMap(GameObject Grid)
        {
            CreatGridData CreateMap = new CreatGridData();
            CreateMap.CreateData(10, 10, Grid);
            CreateMap.CreateObstacle(10, 2);
        }
    }
}