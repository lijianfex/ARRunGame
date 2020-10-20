using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AR 装备球服
/// </summary>
public class ARCloseEquipeCtrl : Controller
{
    public override void Execute(object data = null)
    {
        ShopArgs e = data as ShopArgs;
        GameModel gm = GetModel<GameModel>();
        ARImageUI imageUI = GetView<ARImageUI>();


        gm.CloseInfoList[gm.EquipeClothIndex].State = ItemState.Buy; //把之前装备的更改为已购买


        gm.CloseInfoList[e.index].State = e.state;
        gm.Shot = Game.Instance.Data.GetCloseData(e.index).skillAdd;

        imageUI.TipMessage("此目标已经获取!"+"\n\n"+ "此次双击小熊<color=red>装备</color><color=b>球服</color>，请返回商城查看！");
        imageUI.UpdateUI();
    }
}
