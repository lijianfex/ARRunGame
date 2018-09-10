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

        foreach(FootballInfo info in gm.FootballInfoList)
        {
            if(info.State==ItemState.Equiep)
            {
                gm.FootballInfoList[info.Index].State = ItemState.Buy;                
            }
        }

        gm.FootballInfoList[e.index].State = e.state;
        gm.ShotQulity = Game.Instance.Data.GetFootballData(e.index).skillAdd;

        shop.UpdateUI();
    }
}
