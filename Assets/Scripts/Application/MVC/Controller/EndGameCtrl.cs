﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏结束事件
/// </summary>
public class EndGameCtrl : Controller
{
    public override void Execute(object data = null)
    {
        GameModel gm = GetModel<GameModel>();
        gm.IsPlay = false;

        //TODO 显示结束UI
    }
}
