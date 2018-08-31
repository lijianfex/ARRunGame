﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Model基类
/// </summary>
public abstract class Model 
{
    //名字标识
    public abstract string Name { get; }

    //发送事件
    protected void SendEvent(string eventName,object data=null)
    {
        MVC.SendEvent(eventName, data);
    }
}
