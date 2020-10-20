using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AR 获取球服
/// </summary>
public class ARCloseGetCtrl : Controller
{
    public override void Execute(object data = null)
    {
        ShopArgs e = data as ShopArgs;
        ARImageUI imageUI = GetView<ARImageUI>();
        GameModel gm = GetModel<GameModel>();

        if (gm.GetMoney(e.coin))
        {
            gm.CloseInfoList[e.index].State = e.state;
            imageUI.TipMessage("获得<color=b>梅西球服</color>，金币 <color=b>+300</color>！" + "\n\n" 
                + "<color=red>再次双击小熊</color><color=b>装备球服</color>!");
            imageUI.UpdateUI();
        }
    }
}
