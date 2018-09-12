using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadEquipeCtrl : Controller
{
    public override void Execute(object data = null)
    {
        ShopArgs e = data as ShopArgs;
        GameModel gm = GetModel<GameModel>();
        UIShop shop = GetView<UIShop>();


        gm.HeadInfoList[gm.EquipeHeadIndex].State = ItemState.Buy;


        gm.HeadInfoList[e.index].State = e.state;
        gm.SkillTime = Game.Instance.Data.GetHeadData(e.index).skillAdd;

        shop.UpdateUI();
    }
}
