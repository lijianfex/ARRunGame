using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 初始化注册类
/// </summary>
public class AppInitCtrl : Controller
{
    public override void Execute(object data = null)
    {
        //注册Controller
        RegisterController(Consts.E_EnterScene, typeof(EnterScenesCtrl));

        RegisterController(Consts.E_EndGame, typeof(EndGameCtrl));

        //注册model
        RegisterModel(new GameModel());
    }
}
