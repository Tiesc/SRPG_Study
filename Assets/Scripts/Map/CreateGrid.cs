using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace ELGame
{
    public class CreateGrid : MonoBehaviourSingleton<CreateGrid>
    {
         private GameObject _gameObject;
        private readonly float outerRadius = 16.3f;
        private readonly float innerRadius = 14.1f;

        public void Create(List<Vector3> _listT, List<Vector3> _listObs, GameObject gameObject, GameObject parentObject)
        {
            _gameObject = gameObject;
            foreach (Vector3 vector in _listT)
            {
                GameObject Grid;
                Grid = Instantiate(gameObject, CalcTilePos(vector), Quaternion.identity);
                //把复制体都放到地图节点下
                //todo 这里得思考重新编写，如何编写可以不用查找GridObject，就把生成的地图挂到节点上
                Grid.transform.SetParent(parentObject.transform);
                Grid.name = UtilityHelpTool.RemoveNameClone(Grid.name);
                Grid.name = UtilityHelpTool.ResetName(Grid.name, vector);
                GameObject GridPosData = Grid.transform.Find("GridInfo").gameObject;
                GridPosData.GetComponent<TextMesh>().text = UtilityHelpTool.SetGridPos(vector);
                Color ObGrid = SetColor("1");
                foreach (Vector3 vectorObs in _listObs)
                {
                    if (vector == vectorObs)
                    {
                        ObGrid = SetColor("2");
                    }
                }

                GameObject GridColorData = Grid.transform.Find("Tile").gameObject;
                GridColorData.GetComponent<SpriteRenderer>().color = ObGrid;
            }
        }

        public Vector3 CalcTilePos(Vector3 vector)
        {
            Vector3 vecPos = new Vector3();
            vecPos.x = vector.x * outerRadius;
            vecPos.y = vector.y * innerRadius;
            vecPos.z = vector.z;
            if (vector.y % 2 != 0)
            {
                vecPos.x = vector.x * outerRadius + outerRadius * 0.5f;
            }

            return vecPos;
        }

        public Color SetColor(string state)
        {
            //todo 编写不同类型格子返回的颜色
            Color color = new Color();
            switch (state)
            {
                case "1":
                    color = Color.white;
                    break;
                case "2":
                    color = Color.gray;
                    break;
                case "3":
                    color = Color.red;
                    break;
            }

            return color;
        }
    }
}