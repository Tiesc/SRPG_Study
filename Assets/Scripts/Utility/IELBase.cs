using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ELGame
{
    public interface IELBase
    {
        void Init(params System.Object[] args);
        string Desc();
    }
}