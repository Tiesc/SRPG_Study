using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ELGame
{
    public class CreatGridData : ELBehaviour
    {
        private Color Color;
        private float outerRadius = 1.63f;
        private float innerRadius = 1.41f;
        public int _Row;
        public int _Colum;
        public Vector3[] _Obstruct;
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
        public void CreateObstacle(int num, int space)
        {
            int numObstacle = 0;
            numObstacle = (int) (num / 100.0 * (_Row * _Colum));
            Vector3[] _Obstruct = new Vector3[numObstacle];
            for (int i = 0, lenI = numObstacle; i < lenI; i++)
            {
                int posX = Random.Range(0, _Row);
                int posY = Random.Range(0, _Colum);
                Vector3 tmpPos = new Vector3(posX, posY, -posX - posY);
                //todo  编写创建一个Vector3的模版类,这样才能查找对比数组中是否存在Vector3
//                    if(_Obstruct.IndexOf(tmpPos))
                _Obstruct[i] = tmpPos;
//                Debug.Log("这是啥玩也！！！" + tmpPos);
            }

            foreach (Vector3 pos in _Obstruct)
            {
                Debug.Log("这个数组中都是写什么？？？:::" + pos);
            }

            //todo   编写这里编写计算障碍物的间距数量
        }

        public Vector3 CalcGridPos(int idxR, int idxC)
        {
            Vector3 tmp = new Vector3(0, 0, 0);

            return tmp;
        }

        public bool isOkToPush(Vector3 posA, Vector3 posB, int obs)
        {
            return posA != posB && Math.Abs(posA.x - posB.x) <= obs && Math.Abs(posA.y - posB.y) <= obs &&
                   Math.Abs(posA.z - posB.z) <= obs;
        }
    }
}