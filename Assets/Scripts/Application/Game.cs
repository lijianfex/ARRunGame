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

        //切换场景
        Game.Instance.Level.LoadLevel(1);
    }


}
