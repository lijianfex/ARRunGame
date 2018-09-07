using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 购买道具
/// </summary>
public class BuyToolsCtrl : Controller
{
    public override void Execute(object data = null)
    {
        BuyToolsArgs e = data as BuyToolsArgs;
        GameModel gm = GetModel<GameModel>();
        UIBuyTools buyTools = GetView<UIBuyTools>();
        if(gm.GetMoney(e.CoinCount))
        {
            switch (e.itemType)
            {
                case ItemType.ItemInvincible:
                    gm.Invincible += 1;
                    break;
                case ItemType.ItemMultiply:
                    gm.Multiply += 1;
                    break;
                case ItemType.ItemMagnet:
                    gm.Magnet += 1;
                    break;                
            }
        }
        else
        {
            //TODO
            Debug.Log("金币不足！");
        }
        buyTools.UpdateUI();
    }
}