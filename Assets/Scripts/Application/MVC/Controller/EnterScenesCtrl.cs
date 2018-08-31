using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 进入场景
/// </summary>
public class EnterScenesCtrl : Controller
{
    public override void Execute(object data = null)
    {
        ScenesArgs args = data as ScenesArgs;
        if(args==null)
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
                RegisterView(GameObject.FindWithTag(Tag.player).GetComponent<PlayerMove>());
                break;
            default:
                break;
        }
    }
}