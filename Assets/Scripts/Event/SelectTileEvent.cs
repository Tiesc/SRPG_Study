using UnityEngine;

namespace ELGame
{
    public class SelectTileEvent : MonoBehaviourSingleton<SelectTileEvent>
    {
        public void HandleInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    GameObject Tile = hit.transform.Find("Tile").gameObject;
                    Tile.transform.GetComponent<SpriteRenderer>().color = Color.red;
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