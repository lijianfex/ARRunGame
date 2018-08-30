
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoSingleton<LevelManager>
{

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadLevel(int level)
    {

        ScenesArgs args = new ScenesArgs
        {
            scenesIndex = SceneManager.GetActiveScene().buildIndex
        };

        //发送退出场景事件
        SendEvent(Consts.E_ExitScene,args);

        SceneManager.LoadScene(level, LoadSceneMode.Single);        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("进入场景：" + scene.buildIndex);
        ScenesArgs args = new ScenesArgs
        {
            scenesIndex = scene.buildIndex
        };

        //发送进入场景事件
        SendEvent(Consts.E_EnterScene, args);

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    

    

    //发送事件
    void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }

}
