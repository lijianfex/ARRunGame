using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// View基类
/// </summary>
public abstract class View : MonoBehaviour
{
    //名字标识
    public abstract string Name { get; }

    //事件关心列表
    [HideInInspector]
    public List<string> AttentionList = new List<string>();

    //注册事件关心事件
    public virtual void RegisterAttentionEvent() { }

    //处理事件
    public abstract void HandleEvent(string name, object data = null);

    //发送事件
    protected void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }

    //获取Model
    protected T GetModel<T>() where T:Model
    {
        return MVC.GetModle<T>() as T;
    }

}
