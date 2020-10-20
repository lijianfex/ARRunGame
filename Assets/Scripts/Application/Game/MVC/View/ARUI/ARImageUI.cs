using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// AR 图片识别
/// </summary>
public class ARImageUI : View
{
    
    public Text Message_txt;//提示

    public Text Coin_txt; //金币数

   


    GameModel gm;

    private void Awake()
    {
        gm = GetModel<GameModel>();
        UpdateUI();
    }

    public override string Name
    {
        get
        {
            return Consts.V_ARImageUI;
        }
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

    //更新UI
    public void UpdateUI()
    {
        Coin_txt.text = gm.Coin.ToString();
    }

    public override void HandleEvent(string name, object data = null)
    {

    }





    
    /// <summary>
    /// 点击进入表面识别
    /// </summary>
    public void OnSurfaceTargetClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        Game.Instance.Level.LoadLevel(Levels.ARSurface);


    }

    
    /// <summary>
    /// 点击进入物体识别
    /// </summary>
    public void OnObjectTargetClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        Game.Instance.Level.LoadLevel(Levels.ARObject);


    }

    /// <summary>
    /// 点击退出AR识别
    /// </summary>
    public void OnARExit()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        Game.Instance.Level.LoadLevel(Levels.MainMenu);

    }

    //点击AR足球按钮
    public void FootBallGetBtnClick()
    {
        switch (gm.FootballInfoList[2].State)
        {
            case ItemState.UnBuy:
                Game.Instance.Sound.PlayEffect("Se_UI_Button");
                ShopArgs e = new ShopArgs
                {
                    index = 2,
                    coin = -Game.Instance.Data.GetFootballData(2).coin,
                    state = ItemState.Buy
                };
                SendEvent(Consts.E_AR_FootBallGet, e);//发送事件
                StartCoroutine(JinBiMuiscCor());//金币声
                break;
            case ItemState.Buy:
                Game.Instance.Sound.PlayEffect("Se_UI_Dress");
                ShopArgs ee = new ShopArgs
                {
                    index = 2,
                    coin = 0,
                    state = ItemState.Equiep
                };
                SendEvent(Consts.E_AR_FootBallEquipe, ee);//发送事件
                break;
            case ItemState.Equiep:
                Game.Instance.Sound.PlayEffect("Se_UI_Zhuang");
                TipMessage("此奖励<color=red>已获取</color>，并<color=red>已装备</color>" + "\n\n"
                    + "<color=red>请继续识别其他目标</color>获取奖励<color=red>！</color>");
                break;
        }
    }

    //双击AR小熊
    public void CloseGetDoubleClick()
    {
        switch (gm.CloseInfoList[2].State)
        {
            case ItemState.UnBuy:
                Game.Instance.Sound.PlayEffect("Se_UI_Button");
                ShopArgs e = new ShopArgs
                {
                    index = 2,
                    coin = -Game.Instance.Data.GetCloseData(2).coin,
                    state = ItemState.Buy
                };
                SendEvent(Consts.E_AR_CloseGet, e); //发送事件
                StartCoroutine(JinBiMuiscCor());//金币声
                break;
            case ItemState.Buy:
                Game.Instance.Sound.PlayEffect("Se_UI_Dress");
                ShopArgs ee = new ShopArgs
                {
                    index = 2,
                    coin = 0,
                    state = ItemState.Equiep
                };
                SendEvent(Consts.E_AR_CloseEquipe, ee);//发送事件
                break;
            case ItemState.Equiep:
                Game.Instance.Sound.PlayEffect("Se_UI_Zhuang");
                TipMessage("此奖励<color=red>已获取</color>，并<color=red>已装备</color>" + "\n\n"
                    + "<color=red>请继续识别其他目标</color>获取奖励<color=red>！</color>");
                break;
        }
    }


    //点击FCB介绍文字按钮
    public void ShoseGetBtnClick()
    {
        switch (gm.ShoseInfoList[2].State)
        {
            case ItemState.UnBuy:
                Game.Instance.Sound.PlayEffect("Se_UI_Button");
                ShopArgs e = new ShopArgs
                {
                    index = 2,
                    coin = -Game.Instance.Data.GetShoseData(2).coin,
                    state = ItemState.Buy
                };
                SendEvent(Consts.E_AR_ShoseGet, e);//发送事件
                StartCoroutine(JinBiMuiscCor());//金币声
                break;
            case ItemState.Buy:
                Game.Instance.Sound.PlayEffect("Se_UI_Dress");
                ShopArgs ee = new ShopArgs
                {
                    index = 2,
                    coin = 0,
                    state = ItemState.Equiep
                };
                SendEvent(Consts.E_AR_ShoseEquipe, ee);//发送事件
                break;
            case ItemState.Equiep:
                Game.Instance.Sound.PlayEffect("Se_UI_Zhuang");
                TipMessage("此奖励<color=red>已获取</color>，并<color=red>已装备</color>" + "\n\n"
                    + "<color=red>请继续识别其他目标</color>获取奖励<color=red>！</color>");
                break;
        }
    }


    //点击播放广告按钮
    public void HeadGetPlayBtnClick()
    {
        switch (gm.HeadInfoList[2].State)
        {
            case ItemState.UnBuy:
                Game.Instance.Sound.PlayEffect("Se_UI_Button");
                ShopArgs e = new ShopArgs
                {
                    index = 2,
                    coin = -Game.Instance.Data.GetHeadData(2).coin,
                    state = ItemState.Buy
                };
                SendEvent(Consts.E_AR_HeadGet, e);
                StartCoroutine(JinBiMuiscCor());//金币声
                break;
            case ItemState.Buy:
                Game.Instance.Sound.PlayEffect("Se_UI_Button");
                ShopArgs ee = new ShopArgs
                {
                    index = 2,
                    coin = 0,
                    state = ItemState.Equiep
                };
                SendEvent(Consts.E_AR_HeadEquipe, ee);
                break;
            case ItemState.Equiep:
                Game.Instance.Sound.PlayEffect("Se_UI_Zhuang");
                TipMessage("此奖励<color=red>已获取</color>，并<color=red>已装备</color>" + "\n\n"
                    + "<color=red>请继续识别其他目标</color>获取奖励<color=red>！</color>");
                break;
        }
    }

    //完整播放视频接口---videoController调用
    public void VideoPlayEnd()
    {
        if(gm.IsfirstVideoPaly)
        {
            SendEvent(Consts.E_AR_VideoPlayEnd); //发送事件
        }        
    }
    


}
