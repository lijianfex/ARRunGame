using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipeFootBallCtrl : Controller
{
    public override void Execute(object data = null)
    {
        ShopArgs e = data as ShopArgs;
        GameModel gm = GetModel<GameModel>();
        UIShop shop = GetView<UIShop>();

       
        gm.FootballInfoList[gm.EquipeBallIndex].State = ItemState.Buy; //把之前装备的更改为已购买              


        gm.FootballInfoList[e.index].State = e.state;
        gm.ShotQulity = Game.Instance.Data.GetFootballData(e.index).skillAdd;

        shop.UpdateUI();
    }
}
