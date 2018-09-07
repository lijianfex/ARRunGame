using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 进入场景事件
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
                RegisterView(GameObject.Find("Canvas").transform.Find("UIBuyTools").GetComponent<UIBuyTools>());
                break;
            case 4:
                RegisterView(GameObject.FindWithTag(Tag.player).GetComponent<PlayerMove>());
                RegisterView(GameObject.FindWithTag(Tag.player).GetComponent<PlayerAnim>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIBoard").GetComponent<UIBoard>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIPause").GetComponent<UIPause>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIResume").GetComponent<UIResume>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIDead").GetComponent<UIDead>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIFinalScore").GetComponent<UIFinalScore>());
                break;
            default:
                break;
        }
    }
}