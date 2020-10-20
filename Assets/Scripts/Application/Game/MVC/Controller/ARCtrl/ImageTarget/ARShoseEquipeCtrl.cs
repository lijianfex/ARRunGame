using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// AR 装备鞋子
/// </summary>
public class ARShoseEquipeCtrl : Controller
{
    public override void Execute(object data = null)
    {
        ShopArgs e = data as ShopArgs;
        GameModel gm = GetModel<GameModel>();
        ARImageUI imageUI = GetView<ARImageUI>();


        gm.ShoseInfoList[gm.EquipeShoseIndex].State = ItemState.Buy;//把之前装备的更改为已购买


        gm.ShoseInfoList[e.index].State = e.state;
        gm.SpeedAdd = Game.Instance.Data.GetShoseData(e.index).skillAdd;


        imageUI.TipMessage("此目标已经获取!" + "\n\n" + "此次点击文字<color=red>装备</color><color=b>球鞋</color>，请返回商城查看！");
        imageUI.UpdateUI();

    }
}
