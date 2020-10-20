using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AR 装备头像
/// </summary>
public class ARHeadEquipeCtrl : Controller
{
    public override void Execute(object data = null)
    {
        ShopArgs e = data as ShopArgs;
        GameModel gm = GetModel<GameModel>();
        ARImageUI imageUI = GetView<ARImageUI>();


        gm.HeadInfoList[gm.EquipeHeadIndex].State = ItemState.Buy;//把之前装备的更改为已购买


        gm.HeadInfoList[e.index].State = e.state;
        gm.SkillTime = Game.Instance.Data.GetHeadData(e.index).skillAdd;

        imageUI.TipMessage("此目标已经获取!" + "\n\n" + "此次点击播放键<color=red>装备</color><color=b>头像</color>，请返回商城查看！");
        imageUI.UpdateUI();
    }
}
