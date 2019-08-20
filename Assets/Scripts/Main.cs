using UnityEngine;

namespace ELGame
{
    public class Main : ELBehaviour
    {
        public GameObject Grid;

        private void Awake()
        {
            UnityEngine.Random.InitState((int) System.DateTime.Now.Ticks);
        }

        private void Start()
        {
            MainManage mainManage = gameObject.AddComponent<MainManage>();
            mainManage.CreatGame(Grid);
        }
    }
}