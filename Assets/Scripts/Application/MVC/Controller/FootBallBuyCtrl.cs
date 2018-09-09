using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootBallBuyCtrl : Controller
{
    public override void Execute(object data = null)
    {
        FootBallArgs e = data as FootBallArgs;
        UIShop shop = GetView<UIShop>();
        GameModel gm = GetModel<GameModel>();

        gm.FootballInfoList[e.index].State = e.state;
        gm.Coin -= e.coin;

        shop.UpdateUI();

    }
}
