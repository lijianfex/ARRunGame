using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriberyCtrl : Controller
{
    public override void Execute(object data = null)
    {
        CoinArgs e = data as CoinArgs;
        UIDead dead = GetView<UIDead>();
        GameModel gm = GetModel<GameModel>();
        //花钱     
        if(gm.GetMoney(e.CoinCount))
        {
            dead.Hide();
            dead.BriberyTime++;
            UIResume resume = GetView<UIResume>();
            resume.StartCount();
        }
        else
        {
            Debug.Log("金币不足");
        }

        //继续游戏
       
       

    }
}
