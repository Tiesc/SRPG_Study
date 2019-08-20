using UnityEngine;

namespace ELGame
{
    public class ELBehaviour : MonoBehaviour, IELBase
    {
        private IELBase _ielBaseImplementation;

        public void Init(params object[] args)
        {
            _ielBaseImplementation.Init(args);
        }

        public string Desc()
        {
            return string.Empty;
        }
    }
}