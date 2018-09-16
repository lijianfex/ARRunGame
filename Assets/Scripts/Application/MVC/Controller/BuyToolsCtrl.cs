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
                    gm.Invincible += e.CoinCount > 0 ? 1:-1;
                    break;
                case ItemType.ItemMultiply:
                    gm.Multiply += e.CoinCount > 0 ? 1 : -1;
                    break;
                case ItemType.ItemMagnet:
                    gm.Magnet += e.CoinCount > 0 ? 1 : -1;
                    break;                
            }
        }
        else
        {
            buyTools.TipMessage("金币不足！");
        }
        buyTools.UpdateUI();
    }
}