using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 视频广告播放完成
/// </summary>
public class ARVideoPlayEndCtrl : Controller
{
    public override void Execute(object data = null)
    {
        GameModel gm = GetModel<GameModel>();
        ARImageUI imageUI = GetView<ARImageUI>();

        gm.StartTime += 10f;
        gm.IsfirstVideoPaly = false;
        imageUI.TipMessage("完整观看视频广告!" + "\n\n" + "恭喜游戏<color=red>时间增加</color><color=b>10秒</color>，请返回开始游戏！");
    }
}
