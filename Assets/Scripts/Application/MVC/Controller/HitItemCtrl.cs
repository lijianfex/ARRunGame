using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitItemCtrl : Controller
{
    public override void Execute(object data = null)
    {
        ItemArgs e = data as ItemArgs;
        PlayerMove player = GetView<PlayerMove>();
        GameModel gm = GetModel<GameModel>();
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