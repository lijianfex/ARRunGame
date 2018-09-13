using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 退出场景
/// </summary>
public class ExitScenesCtrl : Controller
{
    public override void Execute(object data = null)
    {
        GameModel gm = GetModel<GameModel>();
        ScenesArgs args = data as ScenesArgs;
        if (args == null)
        {
            return;
        }

        switch (args.scenesIndex)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:                
                break;
            case 4:
                Game.Instance.Pool.ClearDis();
                break;
            default:
                break;
        }
        gm.LastSenceIndex = args.scenesIndex;

    }
}
