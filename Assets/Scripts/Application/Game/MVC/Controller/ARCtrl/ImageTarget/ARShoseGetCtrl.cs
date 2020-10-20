using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// AR 鞋子获取
/// </summary>
public class ARShoseGetCtrl : Controller
{
    public override void Execute(object data = null)
    {
        ShopArgs e = data as ShopArgs;
        ARImageUI imageUI = GetView<ARImageUI>();
        GameModel gm = GetModel<GameModel>();

        if (gm.GetMoney(e.coin))
        {
            gm.ShoseInfoList[e.index].State = e.state;
            imageUI.TipMessage("获得<color=b>红色球鞋</color>，金币 <color=b>+400</color>！" + "\n\n" 
                + "<color=red>再次点击文字</color><color=b>装备球鞋</color>!");
            imageUI.UpdateUI();
        }
    }
}
