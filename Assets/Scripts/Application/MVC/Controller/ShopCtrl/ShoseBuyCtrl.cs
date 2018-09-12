using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoseBuyCtrl : Controller
{
    public override void Execute(object data = null)
    {

        ShopArgs e = data as ShopArgs;
        UIShop shop = GetView<UIShop>();
        GameModel gm = GetModel<GameModel>();

        if (gm.GetMoney(e.coin))
        {
            Debug.Log(gm.Coin);
            gm.ShoseInfoList[e.index].State = e.state;
            shop.UpdateUI();
        }
        else
        {
            //TODO
            Debug.Log("金币不足！");
        }

        
    }
}
