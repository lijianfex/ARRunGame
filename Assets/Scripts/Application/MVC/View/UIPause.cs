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

    public void Show(PauseArgs args)
    {
        gameObject.SetActive(true);
        Dis_txt.text = args.distance.ToString();
        Coin_txt.text = args.coinCount.ToString();
        Socre_txt.text = args.score.ToString();
    }

    public override void HandleEvent(string name, object data = null)
    {
       
    }

    public void OnResumeBtnClick()
    {
        Hide();
        SendEvent(Consts.E_ResumeGame);
    }
}
