using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEquipeCtrl : Controller
{
    public override void Execute(object data = null)
    {
        ShopArgs e = data as ShopArgs;
        GameModel gm = GetModel<GameModel>();
        UIShop shop = GetView<UIShop>();


        gm.CloseInfoList[gm.EquipeClothIndex].State = ItemState.Buy;


        gm.CloseInfoList[e.index].State = e.state;
        gm.Shot = Game.Instance.Data.GetCloseData(e.index).skillAdd;

        shop.UpdateUI();
    }
}
