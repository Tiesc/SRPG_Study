using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace ELGame
{
    public class CreateGrid : EBaseBehaviour
    {
        private GameObject _gameObject;
        private float outerRadius = 16.3f;
        private float innerRadius = 14.1f;

        public void Create(List<Vector3> _listT, List<Vector3> _listObs, GameObject gameObject)
        {
            _gameObject = gameObject;
            foreach (Vector3 vector in _listT)
            {
                GameObject Grid;
                Grid = Instantiate(gameObject, CalcTilePos(vector), Quaternion.identity);
                GameObject MapObject = GameObject.Find("MapObject");
                Grid.transform.parent = MapObject.transform;
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

        public void InsetOther(Vector3 vector, string state, GameObject gameObject, Vector3 vectorPos)
        {
            //todo 编写替换选中位置的颜色
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