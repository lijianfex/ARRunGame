using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoseEquipeCtrl : Controller
{
    public override void Execute(object data = null)
    {
        ShopArgs e = data as ShopArgs;
        GameModel gm = GetModel<GameModel>();
        UIShop shop = GetView<UIShop>();


        gm.ShoseInfoList[gm.EquipeShoseIndex].State = ItemState.Buy;


        gm.ShoseInfoList[e.index].State = e.state;
        gm.SpeedAdd = Game.Instance.Data.GetShoseData(e.index).skillAdd;

        shop.UpdateUI();
    }
}
