using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 暂停游戏的控制器
/// </summary>
public class PauseGameCtrl : Controller
{
    public override void Execute(object data = null)
    {
        
        GameModel gm = GetModel<GameModel>();
        gm.IsPause = true;

        //显示暂停UI
        UIPause pause = GetView<UIPause>();
        PauseArgs e = data as PauseArgs;

        //更新UI
        pause.UpdateUI(e);

        

    }
}
