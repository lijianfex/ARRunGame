using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SoundManager))]
[RequireComponent(typeof(PoolManager))]
[RequireComponent(typeof(LevelManager))]
[RequireComponent(typeof(StaticData))]
public class Game : MonoSingleton<Game>
{
    [HideInInspector]
    public PoolManager Pool;
    [HideInInspector]
    public SoundManager Sound;
    [HideInInspector]
    public LevelManager Level;
    [HideInInspector]
    public StaticData Data;

    void Start()
    {
        //禁止销毁
        DontDestroyOnLoad(gameObject);

        Pool = PoolManager.Instance;
        Sound = SoundManager.Instance;
        Level = LevelManager.Instance;
        Data = StaticData.Instance;

        //游戏启动

        //初始化
        RegisterController(Consts.E_AppInit, typeof(AppInitCtrl));

        SendEvent(Consts.E_AppInit);
       
        //切换场景
        Game.Instance.Level.LoadLevel(3);
    }

    //注册controller
    void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);
    }

    //发送事件
     void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }


}
