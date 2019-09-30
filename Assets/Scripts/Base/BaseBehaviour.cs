using UnityEngine;

namespace ELGame
{
    public class EBaseBehaviour : MonoBehaviour, IGameBase
    {
        private IGameBase _ilBaseImplementation;

        public void Init(params object[] args)
        {
            _ilBaseImplementation.Init(args);
        }

        public string Desc()
        {
            return string.Empty;
        }
    }
}