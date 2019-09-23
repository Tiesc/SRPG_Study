using System.Collections.Generic;
using UnityEngine;
using System;

namespace ELGame
{
    public class EventManage : MonoBehaviourSingleton<EventManage>
    {
        EventFind testFind = new EventFind();
        EventStart testStart = new EventStart();
        SelectTileEvent selectTileEvent = new SelectTileEvent();

        public void Update()
        {
            Debug.Log("打印点什么东西让我康康!!!!!!");
            if (Input.GetMouseButtonDown(0))
            {
                testFind.handler += testStart.Run;
                testFind.handler += selectTileEvent.HandleInput;
                testFind.OnClick();
                testFind.handler -= testStart.Run;
                testFind.handler -= selectTileEvent.HandleInput;
                testFind.OnClick();
            }
        }
    }

    //事件的订阅者
    public class EventStart
    {
        public void Run()
        {
            Debug.Log("测试事件系统的编写::::::::::EventStart");
        }
    }

    //事件的发布者
    public class EventFind : MonoBehaviourSingleton<EventFind>
    {
        public delegate void GameEventHandler();

        public event GameEventHandler handler;

        public virtual void OnClick()
        {
            if (handler != null)
            {
                handler(); /* 事件被触发 */
            }
            else
            {
                Debug.Log("这事件触发怎么那么难懂？？？？？？");
            }
        }
    }
}