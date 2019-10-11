using UnityEngine;

namespace ELGame
{
    public class SelectTileEvent : MonoBehaviourSingleton<SelectTileEvent>
    {
        private GameObject selectTile;
        private Color selectColor;

        public void HandleInput(ELGame.IGameEvent msg)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("这是什么情况？？？？？？我也是醉了！！！！");
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    GameObject Tile = hit.transform.Find("Tile").gameObject;
                    if (selectTile)
                    {
                        if (selectTile.transform != Tile.transform)
                        {
                            selectTile.transform.GetComponent<SpriteRenderer>().color = selectColor;
                            selectColor = Tile.transform.GetComponent<SpriteRenderer>().color;
                            Tile.transform.GetComponent<SpriteRenderer>().color = Color.red;
                            selectTile = Tile;
                        }
                    }
                    else
                    {
                        selectTile = Tile;
                        selectColor = Tile.transform.GetComponent<SpriteRenderer>().color;
                        Tile.transform.GetComponent<SpriteRenderer>().color = Color.red;
                    }
                }
            }
        }

        public void TouchCell(Vector3 position)
        {
            position = transform.InverseTransformPoint(position);
            Debug.Log("touched at " + position);
        }
    }
}