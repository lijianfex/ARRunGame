using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AR 头像获取
/// </summary>
public class ARHeadGetCtrl : Controller
{
    public override void Execute(object data = null)
    {
        ShopArgs e = data as ShopArgs;
        ARImageUI imageUI = GetView<ARImageUI>();
        GameModel gm = GetModel<GameModel>();


        if (gm.GetMoney(e.coin))
        {
            gm.HeadInfoList[e.index].State = e.state;
            imageUI.TipMessage("获得<color=b>粉红头像</color>，金币 <color=b>+500</color>！" + "\n\n"
                + "<color=red>再次点击播放键</color><color=b>装备头像</color>!");
            imageUI.UpdateUI();
        }
        
    }
}
