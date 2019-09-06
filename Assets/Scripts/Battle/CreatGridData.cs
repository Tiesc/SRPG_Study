using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ELGame
{
    public class CreatGridData : ELBehaviour
    {
        public int _AxleQ, _AxleS, _AxleR;
        public List<Vector3> _Tile = new List<Vector3>();
        public List<Vector3> _TilePos = new List<Vector3>();
        public List<Vector3> _Obstruct = new List<Vector3>();
        CreateGrid Grid = new CreateGrid();

        /*
         * @function 创建地图中的点
         */
        public void CreateData(int q, int s)
        {
            if (!(typeof(int) == q.GetType() && typeof(int) == s.GetType()))
            {
                return;
            }

            _AxleQ = q;
            _AxleS = s;
            _AxleR = -q - s;

            for (int i = 0, lenI = q; i < q; i++)
            {
                for (int j = 0, lenJ = s; j < s; j++)
                {
                    Vector3 vector = new Vector3(i, j, 0);
                    _Tile.Add(vector);
                }
            }
        }

        /*
         * @function 创建地图中的障碍物数据
         */
        public void CreateObstacleData(int num, int space)
        {
            List<int> obslist = new List<int>();
            for (int i = 0, lenI = num; i < num;)
            {
                int _reIdx = Random.Range(0, _Tile.Count());
                if (!ELHelpTool.isInList(obslist, _reIdx))
                {
                    obslist.Add(_reIdx);
                    i++;
                }
            }

            foreach (Vector3 vector in _Tile)
            {
                foreach (int i in obslist)
                {
                    if (_Tile[i] == vector)
                    {
                        _Obstruct.Add(vector);
                    }
                }
            }
        }


        public void drawMap(GameObject gameObject)
        {
            Grid.Create(_Tile, _Obstruct, gameObject);
//            Grid.InsetOther(_Tile, _Obstruct, gameObject);
        }

        public bool isOkToPush(Vector3 posA, Vector3 posB, int obs)
        {
            return posA != posB && Math.Abs(posA.x - posB.x) <= obs && Math.Abs(posA.y - posB.y) <= obs &&
                   Math.Abs(posA.z - posB.z) <= obs;
        }

        public void CalcGridConterByCube(int q, int s, int r)
        {
            //使用立方体坐标生成地图数据
        }

        public void CalcGridConterByDoubled(int q, int s, int r)
        {
            //使用翻倍坐标生成地图数据
        }

        public void CalcGridConterByAxial(int idxR, int idxC)
        {
            //使用轴坐标生成地图数据
        }

        public void CalcGridConterByOffset(int idxR, int idxC)
        {
            //使用偏移坐标生成地图数据
        }
    }
}