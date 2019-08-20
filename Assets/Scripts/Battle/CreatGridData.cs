using System;
using UnityEngine;

namespace ELGame
{
    public class CreatGridData : ELBehaviour
    {
        private Color Color;
        private float outerRadius = 1.63f;
        private float innerRadius = 1.41f;
        public int _Row;
        public int _Colum;
        public int _Obstruct;
        private GameObject gameObject;

        /*
         * @function 创建地图
         */
        public void CreateData(int row, int colum, GameObject objGame)
        {
            if (!(typeof(int) == row.GetType() && typeof(int) == colum.GetType()))
            {
                return;
            }

            GameObject MainCamera = GameObject.Find("Main Camera");
            Vector3 initPos = new Vector3(row * outerRadius / 2, colum * innerRadius / 2, -10);
            MainCamera.transform.position = initPos;

            _Row = row;
            _Colum = colum;
            gameObject = objGame;
            CalcGridConter(row, colum);
        }

        public void CalcGridConter(int idxR, int idxC)
        {
            Vector3 vector = new Vector3();
            for (int i = 0; i < idxR; i++)
            {
                for (int j = 0; j < idxC; j++)
                {
                    vector.x = (i * outerRadius);
                    vector.y = (j * innerRadius);
                    vector.z = 0;
                    if (j % 2 != 0)
                    {
                        vector.x = (i * outerRadius) + outerRadius * 0.5f;
                    }

                    Vector3 Pos = new Vector3(i, j, 0 - i - j);
                    CreateGrid Grid = new CreateGrid();
                    Grid.Create(vector, "1", gameObject, Pos);
                }
            }
        }

        /*
         * @function 创建地图中的障碍物
         */
        public void CreateObstacle(int num)
        {
            if (!(num < _Row * _Colum))
            {
                Debug.Log("设置的障碍太多了！！！！");
                return;
            }
            //todo   编写这里
            Double numScale = num / (_Row * _Colum);
        }

        public Vector3 CalcGridPos(int idxR, int idxC)
        {
            Vector3 tmp = new Vector3(0, 0, 0);

            return tmp;
        }
    }
}