using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

namespace ELGame
{
    public enum RegEventResult
    {
        Success,
        Failed,
    }

    public delegate void GameEventHandler();

    public class GameEventHandlerItem
    {
        //创建事件的信息
        class EventInfo
        {
            public GameEventHandler _handler;
            public string _listener;
            public int _times;

            public EventInfo(string listener, GameEventHandler handler, int times)
            {
                _listener = listener;
                _handler = handler;
                _times = times;
            }
        }

        private string eventKey;

        private List<EventInfo> eventInfos = new List<EventInfo>();

        private event GameEventHandler saveEvent;

        public GameEventHandlerItem(string key, string listener, GameEventHandler handler, int times)
        {
            eventKey = key;
            eventInfos.Add(new EventInfo(listener, handler, times));
            saveEvent += handler;
        }

        //注册
        public RegEventResult AddEventHandler(string listener, GameEventHandler handler, int time)
        {
            eventInfos.Add(new EventInfo(listener, handler, time));
            saveEvent += handler;
            return RegEventResult.Success;
        }


        //广播某个事件
        public void Run()
        {
            saveEvent();

            for (int i = eventInfos.Count - 1; i >= 0; --i)
            {
                if (eventInfos[i]._times >= 999)
                    continue;

                eventInfos[i]._times -= 1;

                if (eventInfos[i]._times <= 0)
                {
                    //移除
                    saveEvent -= eventInfos[i]._handler;
                    eventInfos.RemoveAt(i);
                }
            }
        }

        //获取当前注册的监听数量
        public int ListenerCount
        {
            get { return eventInfos.Count; }
        }

        //根据对象清空
        public void Remove(string listener)
        {
            for (int i = eventInfos.Count - 1; i >= 0; --i)
            {
                if (string.Compare(eventInfos[i]._listener, listener, true) == 0)
                {
                    //移除
                    saveEvent -= eventInfos[i]._handler;
                    eventInfos.RemoveAt(i);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < eventInfos.Count; i++)
            {
                strBuilder.AppendFormat("{0}, Name:{1}, Time:{2}", i, eventInfos[i]._listener, eventInfos[i]._times);
            }

            return strBuilder.ToString();
        }
    }

    public class EventManage : BaseManager<EventManage>
    {
        public override string MangerName => "EventManager";

        private Dictionary<string, GameEventHandlerItem> eventsDic = new Dictionary<string, GameEventHandlerItem>();

        private static string test = "test";

        private static string key = "test";
        private static int times = 999;

        private GameEventHandlerItem testEventHandlerItem;

        public override void InitManager()
        {
            //走父类中的初始化函数(也就是继承父类的函数)
            base.InitManager();
            //初始化当前的事件池
//            Reset();
        }

        public void AddEvent(GameEventHandler handler)
        {
            testEventHandlerItem = new GameEventHandlerItem(key, test, handler, times);
            testEventHandlerItem?.Run();
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
            }
        }
    }
}