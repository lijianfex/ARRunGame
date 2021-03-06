﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 贿赂控制
/// </summary>
public class BriberyCtrl : Controller
{
    public override void Execute(object data = null)
    {
        CoinArgs e = data as CoinArgs;
        UIDead dead = GetView<UIDead>();
        GameModel gm = GetModel<GameModel>();
        UIBoard uIBoard = GetView<UIBoard>();
        //花钱     
        if(gm.GetMoney(e.CoinCount))
        {
            dead.Hide();
            dead.BriberyTime++;
            UIResume resume = GetView<UIResume>();
            resume.StartCount();//继续游戏
            uIBoard.UpdateUI();
        }
        else
        {
            dead.TipMessage("金币不足！");
        }

        
       
       

    }
}
