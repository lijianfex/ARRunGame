using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoSingleton<LevelManager>
{
    

    public void LoadLevel(int level)
    {
        
        ScenesArgs args = new ScenesArgs();
        args.scenesIndex = SceneManager.GetActiveScene().buildIndex;

        //发送退出场景事件
        SendEvent(Consts.E_ExitScene,args);

        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    private void OnLevelWasLoaded(int level)
    {
        ScenesArgs args = new ScenesArgs();
        args.scenesIndex = level;

        //发送进入场景事件
        SendEvent(Consts.E_EnterScene, args);
    }

    //发送事件
    void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }

}
