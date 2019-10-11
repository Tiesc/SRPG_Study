using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ELGame
{
    public class CreateMapData
    {
           public int _AxleQ, _AxleS, _AxleR;
        public List<Vector3> _Tile = new List<Vector3>();
        public List<Vector3> _TilePos = new List<Vector3>();
        public List<Vector3> _Obstruct = new List<Vector3>();

        /*
         * @function 创建地图中的点
         */
        public List<Vector3> CreateData(int q, int s)
        {
            if (!(typeof(int) == q.GetType() && typeof(int) == s.GetType()))
            {
                return null;
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

            return _Tile;
        }

        /*
         * @function 创建地图中的障碍物数据
         */
        public List<Vector3> CreateObstacleData(int num, int space)
        {
            List<int> obslist = new List<int>();
            for (int i = 0, lenI = num; i < num;)
            {
                int _reIdx = Random.Range(0, _Tile.Count());
                if (!UtilityHelpTool.isInList(obslist, _reIdx))
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

            return _Obstruct;
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