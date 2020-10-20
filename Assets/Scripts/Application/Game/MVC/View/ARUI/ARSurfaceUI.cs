using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI 表面识别
/// </summary>
public class ARSurfaceUI : View
{
    public Text Message_txt;//提示

    public Text Coin_txt; //金币数

    private bool isGetMagnet = false;
    private bool isGetMultiply = false;


    GameModel gm; // 游戏数据

    private void Awake()
    {
        gm = GetModel<GameModel>();
        isGetMagnet = false;
        isGetMultiply = false;
        UpdateUI();

    }

    //更新UI
    public void UpdateUI()
    {
        Coin_txt.text = gm.Coin.ToString();
    }


    //显示提示信息
    public void TipMessage(string msg)
    {
        Message_txt.transform.parent.gameObject.SetActive(true);
        Message_txt.text = msg;
        StartCoroutine(MessageCor());
    }
    IEnumerator MessageCor()
    {
        yield return new WaitForSeconds(4f);
        Message_txt.transform.parent.gameObject.SetActive(false);
    }

    //金币音效
    IEnumerator JinBiMuiscCor()
    {
        yield return new WaitForSeconds(0.5f);
        Game.Instance.Sound.PlayEffect("Se_UI_JinBi");
    }

    public override string Name
    {
        get
        {
            return Consts.V_ARSurfaceUI;
        }
    }

    public override void HandleEvent(string name, object data = null)
    {
       
    }

    /// <summary>
    /// 图片识别按钮事件
    /// </summary>
    public void OnImageTargetClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        Game.Instance.Level.LoadLevel(Levels.ARImage);

    }

    /// <summary>
    /// 模型识别按钮事件
    /// </summary>
    public void OnObjectTargetClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        Game.Instance.Level.LoadLevel(Levels.ARObject);


    }

    /// <summary>
    /// 退出AR按钮事件
    /// </summary>
    public void OnARExit()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        Game.Instance.Level.LoadLevel(Levels.MainMenu);

    }


    /// <summary>
    /// AR 点击吸铁石
    /// </summary>
    public void GetMagnetBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        BuyToolsArgs e = new BuyToolsArgs
        {
            itemType = ItemType.ItemMagnet,
            CoinCount = -100
        };
        if(isGetMagnet==false)
        {
            SendEvent(Consts.E_AR_ToolsGet, e);
            StartCoroutine(JinBiMuiscCor());
            isGetMagnet = true;
        }
        else
        {
            Game.Instance.Sound.PlayEffect("Se_UI_Zhuang");
            TipMessage("道具<color=b>吸币磁铁</color>，<color=red>已获取至道具库</color>！" + "\n\n"
                + "返回道具页<color=red>出售</color>" + "\n" + "返回进行游戏<color=red>使用</color>!");
        }
    }

    /// <summary>
    /// AR 点击金币加倍
    /// </summary>
    public void GetMultiplyBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        BuyToolsArgs e = new BuyToolsArgs
        {
            itemType = ItemType.ItemMultiply,
            CoinCount = -200
        };
        if (isGetMultiply == false)
        {
            SendEvent(Consts.E_AR_ToolsGet, e);
            StartCoroutine(JinBiMuiscCor());
            isGetMultiply = true;
        }
        else
        {
            Game.Instance.Sound.PlayEffect("Se_UI_Zhuang");
            TipMessage("道具<color=b>金币加倍</color>，<color=red>已获取至道具库</color>！" + "\n\n"
                + "返回道具页<color=red>出售</color>" + "\n" + "返回进行游戏<color=red>使用</color>!");
        }
    }
}
