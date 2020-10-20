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

        GameModel gm = GetModel<GameModel>();

        switch (args.scenesIndex)
        {

            case 1:               
                Game.Instance.Sound.PlayBG("Bgm_JieMian");                
                RegisterView(GameObject.Find("Canvas").transform.Find("UIMainMenu").GetComponent<UIMainMenu>());
                break;
            case 2:                
                Game.Instance.Sound.PlayBG("Bgm_JieMian");                
                RegisterView(GameObject.Find("Canvas").transform.Find("UIShop").GetComponent<UIShop>());
                break;
            case 3:               
                Game.Instance.Sound.PlayBG("Bgm_JieMian");                
                RegisterView(GameObject.Find("Canvas").transform.Find("UIBuyTools").GetComponent<UIBuyTools>());
                break;
            case 4:
                Game.Instance.Sound.PlayBG("Bgm_ZhanDou");
                RegisterView(GameObject.FindWithTag(Tag.player).GetComponent<PlayerMove>());
                RegisterView(GameObject.FindWithTag(Tag.player).GetComponent<PlayerAnim>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIBoard").GetComponent<UIBoard>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIPause").GetComponent<UIPause>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIResume").GetComponent<UIResume>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIDead").GetComponent<UIDead>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIFinalScore").GetComponent<UIFinalScore>());                               
                gm.IsPause = false;
                gm.IsPlay = true;
                break;
            case 5:                
                if(gm.IsBgmPlay)
                {
                    Game.Instance.Sound.PauseBGM();
                    gm.IsBgmPlay = true;
                }
                RegisterView(GameObject.Find("Canvas").transform.Find("ARUI").GetComponent<ARUI>());
                break;
            case 6:
                RegisterView(GameObject.FindWithTag(Tag.ARImageUI).GetComponent<ARImageUI>());
                break;
            case 7:
                RegisterView(GameObject.FindWithTag(Tag.ARSurfaceUI).GetComponent<ARSurfaceUI>());
                break;
            case 8:
                RegisterView(GameObject.FindWithTag(Tag.ARObjectUI).GetComponent<ARObjectUI>());
                break;
            default:
                break;
        }
    }
}