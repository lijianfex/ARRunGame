﻿using System.Collections;
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

        RegisterController(Consts.E_PauseGame, typeof(PauseGameCtrl));

        RegisterController(Consts.E_ResumeGame, typeof(ResumeGameCtrl));

        RegisterController(Consts.E_HitItem, typeof(HitItemCtrl));


        //注册model
        RegisterModel(new GameModel());
        //初始化
        GameModel gm = GetModel<GameModel>();
        gm.Init();


    }
}
