using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ELGame
{
    //超简单泛型
    public class LiteSingleton<T>
        where T : new()
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }

                return instance;
            }
        }
    }

    //普通泛型单例
    public class NormalSingleton<T>
        where T : IELBase, new()

    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }

                return instance;
            }
        }
    }

    //继承MonoBehaviour的泛型单例
    public class MonoBehaviourSingleton<T> : ELBehaviour
        where T : MonoBehaviourSingleton<T>
    {
        private static T instance;

        public static T Instance
        {
            get { return instance; }
        }

        public void Awake()
        {
            instance = this as T;
        }
    }
}