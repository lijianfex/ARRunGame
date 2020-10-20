using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AR 装备足球
/// </summary>
public class ARFootBallEquipeCtrl : Controller
{
    public override void Execute(object data = null)
    {
        ShopArgs e = data as ShopArgs;        
        GameModel gm = GetModel<GameModel>();
        ARImageUI imageUI = GetView<ARImageUI>();

        gm.FootballInfoList[gm.EquipeBallIndex].State = ItemState.Buy; //把之前装备的更改为已购买

        gm.FootballInfoList[e.index].State = e.state;
        gm.ShotQulity = Game.Instance.Data.GetFootballData(e.index).skillAdd;

        
        imageUI.TipMessage("此目标已经获取!" + "\n\n" + "此次点击图标<color=red>装备</color><color=b>足球</color>，请返回商城查看！");
        imageUI.UpdateUI();

    }
}
