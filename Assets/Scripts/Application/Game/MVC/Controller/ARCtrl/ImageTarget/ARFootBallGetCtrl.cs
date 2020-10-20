using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AR 获得足球
/// </summary>
public class ARFootBallGetCtrl : Controller
{
    public override void Execute(object data = null)
    {
        ShopArgs e = data as ShopArgs;
        ARImageUI imageUI = GetView<ARImageUI>();
        GameModel gm = GetModel<GameModel>();

        if (gm.GetMoney(e.coin))
        {
            gm.FootballInfoList[e.index].State = e.state;
            imageUI.TipMessage("获得<color=b>旋风足球</color>，金币 <color=b>+400</color>！" + "\n\n"
                + "<color=red>再次点击图标</color><color=b>装备足球</color>!");
            imageUI.UpdateUI();            
        }
        
    }

}
