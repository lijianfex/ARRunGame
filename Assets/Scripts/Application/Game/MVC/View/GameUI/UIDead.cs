﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 死亡界面
/// </summary>
public class UIDead : View
{
    public Text BriberyCoin_txt;

    //-----提示----
    public Text Message_txt;//提示

    int m_BriberyTime=1;//贿赂次数

    public override string Name
    {
        get
        {
            return Consts.V_UIDead;
        }
    }

    public int BriberyTime
    {
        get
        {
            return m_BriberyTime;
        }

        set
        {
            m_BriberyTime = value;
        }
    }

    public override void HandleEvent(string name, object data = null)
    {
       
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void UpdateUI()
    {
        BriberyCoin_txt.text = (500 * BriberyTime).ToString();
    }

    //鼠标点击关闭
    public void OnCloseBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        SendEvent(Consts.E_FinalShowUI);
    }

    //点击贿赂
    public void OnBriberyBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        CoinArgs e = new CoinArgs
        {
            CoinCount = 500 * BriberyTime
        };
        SendEvent(Consts.E_BriberyClick,e);//----->BriberyCtrl
    }

    //---提示---
    public void TipMessage(string msg)
    {
        Message_txt.gameObject.SetActive(true);
        Message_txt.text = msg;
        StartCoroutine(MessageCor());
    }

    IEnumerator MessageCor()
    {
        yield return new WaitForSeconds(2f);
        Message_txt.gameObject.SetActive(false);
    }
}
