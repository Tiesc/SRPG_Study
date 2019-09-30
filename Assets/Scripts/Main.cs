using UnityEngine;

namespace ELGame
{
    public class Main : MonoBehaviourSingleton<Main>
    {
        public GameObject Grid;

        private void Awake()
        {
            Random.InitState((int) System.DateTime.Now.Ticks);
            DontDestroyOnLoad(this);
            PrepareManage();
        }

        private void PrepareManage()
        {
            gameObject.AddComponent<MainManage>();
            MainManage.Instance.InitManager();
        }

        private void OnGUI()
        {
            if (GUI.Button(new Rect(0, 0, 100, 50), "Start Game"))
            {
                MainManage.Instance.CreatGame(Grid);
            }
        }
    }
}