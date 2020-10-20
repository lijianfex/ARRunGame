using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
///主页UI
/// </summary>
public class UIMainMenu : View
{

    [Header("-----主页角色足球皮肤-------")]
    public SkinnedMeshRenderer ClothRender;//角色皮肤
    public MeshRenderer BallRender;//足球的皮肤

    [Header("------声音按钮图片----------")]
    public GameObject BgmPlay_img;
    public GameObject BgmPause_img;

    public Text Coin_txt;//金币数

    GameModel gm;//游戏全局数据模块

    private void Awake()
    {
        gm = GetModel<GameModel>();
        ClothRender.material.mainTexture = Game.Instance.Data.GetCloseData(gm.EquipeClothIndex).texture;
        BallRender.material = Game.Instance.Data.GetFootballData(gm.EquipeBallIndex).material;
        ShowBgmPlayPauseImg(); //显示静音/播放 图片按钮
        UpdateUI(); //更新UI
    }


    public override string Name
    {
        get
        {
            return Consts.V_UIMainMenu;
        }
    }

    public override void HandleEvent(string name, object data = null)
    {
        
    }

    //更新UI
    public void UpdateUI()
    {
        Coin_txt.text = gm.Coin.ToString(); //更新金币数
    }

    //点击商城按钮
    public void OnShopBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        Game.Instance.Level.LoadLevel(Levels.Shop);
    }

    //点击开始游戏按钮，进入道具页
    public void OnPlayBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        Game.Instance.Level.LoadLevel(Levels.BuyTools);
    }

    //点击背景播放/静音按钮
    public void OnBgmPlayPauseBtnClick()
    {
        if(!gm.IsBgmPlay)
        {
            Game.Instance.Sound.PlayBGM();
        }
        else
        {
            Game.Instance.Sound.PauseBGM();
        }
        ShowBgmPlayPauseImg();

    }

    private void ShowBgmPlayPauseImg()
    {
        if (gm.IsBgmPlay)
        {
            BgmPlay_img.SetActive(true);
            BgmPause_img.SetActive(false);
        }
        else
        {
            BgmPlay_img.SetActive(false);
            BgmPause_img.SetActive(true);
        }
    }

    //点击AR交互按钮
    public void OnARBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        Game.Instance.Level.LoadLevel(Levels.AR);
    }


    //点击退出游戏App
    public void OnExitBtnClick()
    {
        Application.Quit();
    }
}
