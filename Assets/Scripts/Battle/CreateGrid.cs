using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ELGame
{
    public class CreateGrid : ELBehaviour
    {
//        CreatGridData GridData = new CreatGridData();
//        public GameObject Grid;

        public void Create(Vector3 vector, string state, GameObject gameObject, Vector3 vectorPos)
        {
            GameObject Grid = Object.Instantiate(gameObject, vector, Quaternion.identity);
            GameObject MapObject = GameObject.Find("MapObject");
            Grid.transform.parent = MapObject.transform;
            Grid.name = ELHelpTool.RemoveNameClone(Grid.name);
            GameObject GridPosData = Grid.transform.Find("GridInfo").gameObject;
            GridPosData.GetComponent<TextMesh>().text = ELHelpTool.SetGridPos(vectorPos);
            Color ObGrid = SetColor(state);
            GameObject GridColorData = Grid.transform.Find("Tile").gameObject;
            GridColorData.GetComponent<SpriteRenderer>().color = ObGrid;
            //todo   编写设置不同格子的颜色;
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
            }

            return color;
        }
    }
}