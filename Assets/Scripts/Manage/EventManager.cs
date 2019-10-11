/*
 * 注册事件->事件字典->事件数组
 */

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

    public delegate void GameEventHandler(ELGame.IGameEvent msg);

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
        public void Run(IGameEvent msg)
        {
            saveEvent(msg);

            for (int i = eventInfos.Count - 1; i >= 0; --i)
            {
                if (eventInfos[i]._times >= GameConfig.Infinity)
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

        private GameEventHandlerItem testEventHandlerItem;

        //注册
        /*
        * key 关键字
        * listener 监听者(事件的执行者)
        * handler 消息
        * times 执行次数
        * dic 消息字典
        */
        public RegEventResult Register(string key, string listener, ELGame.GameEventHandler handler,
            int times = GameConfig.Infinity, Dictionary<string, GameEventHandlerItem> dic = null)
        {
            
            Dictionary<string, GameEventHandlerItem> refDic = null;

            if (dic == null)
                refDic = eventsDic;
            else
                refDic = dic;

            //如果不传dic则默认是全局广播
            GameEventHandlerItem delegateItem = null;

            if (refDic.TryGetValue(key.ToUpper(), out delegateItem))
            {
                return delegateItem.AddEventHandler(listener, handler, times);
            }
            else
            {
                //没有
                refDic.Add(key.ToUpper(), new GameEventHandlerItem(key, listener, handler, times));

                if (dic == null)
                    MgrLog(string.Format("注册世界事件:{0}, 相应次数:{1}", key, times));
                else
                    MgrLog(string.Format("注册本地事件:{0}, 相应次数:{1}", key, times));

                return RegEventResult.Success;
            }
        }

        //根据key清空
        public void UnregisterByKey(
            string key,
            Dictionary<string, GameEventHandlerItem> dic = null)
        {
            Dictionary<string, GameEventHandlerItem> refDic = null;

            if (dic == null)
                refDic = eventsDic;
            else
                refDic = dic;

            refDic.Remove(key.ToUpper());
        }

        //根据注册对象移除
        public void Unregister(
            string listener,
            Dictionary<string, GameEventHandlerItem> dic = null)
        {
            Dictionary<string, GameEventHandlerItem> refDic = null;

            if (dic == null)
                refDic = eventsDic;
            else
                refDic = dic;

            List<string> removeList = new List<string>();
            foreach (var eventListItem in refDic)
            {
                eventListItem.Value.Remove(listener);
                if (eventListItem.Value.ListenerCount == 0)
                {
                    removeList.Add(eventListItem.Key);
                }
            }

            //删除
            foreach (var item in removeList)
            {
                refDic.Remove(item);
            }
        }

        //调用
        public void Run(string key, IGameEvent msg, Dictionary<string, GameEventHandlerItem> dic = null)
        {
            Dictionary<string, GameEventHandlerItem> refDic = null;

            if (dic == null)
                refDic = eventsDic;
            else
                refDic = dic;

            GameEventHandlerItem delegateItem = null;
            if (refDic.TryGetValue(key.ToUpper(), out delegateItem))
            {
                delegateItem?.Run(msg);
                if (delegateItem.ListenerCount == 0)
                {
                    refDic.Remove(key.ToUpper());
                }
            }
            else
            {
                MgrLog("NO REGISTER KEY:" + key);
            }
        }

        //重置
        public void Reset(Dictionary<string, GameEventHandlerItem> dic = null)
        {
            Dictionary<string, GameEventHandlerItem> refDic = null;

            if (dic == null)
                refDic = eventsDic;
            else
                refDic = dic;

            refDic.Clear();
            MgrLog("EVENT MANAGER REST COMPLETE");
        }

        public void Desc(Dictionary<string, GameEventHandlerItem> dic = null)
        {
            Dictionary<string, GameEventHandlerItem> refDic = null;

            if (dic == null)
                refDic = eventsDic;
            else
                refDic = dic;

            string name = "(Global)";
            if (dic != null)
                name = "(Local)";

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("**********************************\n");
            stringBuilder.AppendFormat("Show Registed event: {0}\n", name);
            stringBuilder.AppendFormat("**********************************\n");

            foreach (var eventList in refDic)
            {
                stringBuilder.AppendFormat("Key={0},Count={1}\n", eventList.Key, eventList.Value.ListenerCount);
                stringBuilder.AppendFormat(eventList.Value.ToString());
                stringBuilder.AppendFormat("------------------------------\n");
            }

            stringBuilder.AppendFormat("**********************************\n");

            MgrLog(stringBuilder.ToString());
        }

        public override void InitManager()
        {
            //走父类中的初始化函数(也就是继承父类的函数)
            base.InitManager();
            //初始化当前的事件池
            Reset();
        }
    }
}