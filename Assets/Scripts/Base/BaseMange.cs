using UnityEngine;

namespace ELGame
{
    public abstract class BaseManager<T>
        : MonoBehaviourSingleton<T>
        where T : BaseManager<T>
    {
        public virtual string MangerName => "BaseManager";

        [SerializeField] public bool DebugMode = false;

        public virtual void InitManager()
        {
           
        }

        public void MgrLog(string info)
        {
            if (DebugMode)
                Debug.LogFormat("{0} :::: {1}",
                    MangerName,
                    info);
        }

        public virtual void ResetManager()
        {
        }
    }
}