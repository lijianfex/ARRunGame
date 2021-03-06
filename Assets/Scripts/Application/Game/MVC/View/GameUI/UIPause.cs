﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 游戏暂停UI
/// </summary>
public class UIPause : View
{
    public Text Dis_txt;
    public Text Coin_txt;
    public Text Socre_txt;

    public SkinnedMeshRenderer ClothRender;
    public MeshRenderer BallRender;
    GameModel gm;

    private void Awake()
    {

        gm = GetModel<GameModel>();

        //更新皮肤与球
        ClothRender.material.mainTexture = Game.Instance.Data.GetCloseData(gm.EquipeClothIndex).texture;
        BallRender.material = Game.Instance.Data.GetFootballData(gm.EquipeBallIndex).material;
    }

    public override string Name
    {
        get
        {
            return Consts.V_UIPause;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        
    }

    //更新UI
    public void UpdateUI(PauseArgs args)
    {
        Dis_txt.text = args.distance.ToString();
        Coin_txt.text = args.coinCount.ToString();
        Socre_txt.text = args.score.ToString();
    }

    public override void HandleEvent(string name, object data = null)
    {
       
    }

    //点击继续
    public void OnResumeBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        Hide();
        SendEvent(Consts.E_ResumeGame);
    }

    public void OnReturnBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        Game.Instance.Level.LoadLevel(Levels.BuyTools);
    }
}
