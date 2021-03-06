﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 碰到奖励品
/// </summary>
public class HitItemCtrl : Controller
{
    public override void Execute(object data = null)
    {
        ItemArgs e = data as ItemArgs;          
        GameModel gm = GetModel<GameModel>();

        PlayerMove player = GetView<PlayerMove>();
        UIBoard uiBoard = GetView<UIBoard>();        
        
        switch (e.itemtype)
        {
            case ItemType.ItemInvincible:
                player.HitInvincible();
                gm.Invincible -= e.hitCount;
                uiBoard.HitInvincible();
                break;
            case ItemType.ItemMultiply:
                player.HitMutiply();
                gm.Multiply -= e.hitCount;
                uiBoard.HitMutiply();
                break;
            case ItemType.ItemMagnet:
                player.HitMagnet();
                gm.Magnet -= e.hitCount;
                uiBoard.HitMagnet();
                break;
            case ItemType.ItemAddTime:
                player.HitAddTime();
                break;
        }
        uiBoard.UpdateUI();
    }
}