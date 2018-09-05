using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIDead : View
{
    public Text BriberyCoin_txt;
    int m_BriberyTime=1;

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
        BriberyCoin_txt.text = (500 * BriberyTime).ToString();
        gameObject.SetActive(true);
    }

    //鼠标点击关闭
    public void OnCloseBtnClick()
    {
        SendEvent(Consts.E_FinalShowUI);
    }

    //点击贿赂
    public void OnBriberyBtnClick()
    {
        CoinArgs e = new CoinArgs
        {
            CoinCount = 500 * BriberyTime
        };
        SendEvent(Consts.E_BriberyClick,e);//----->BriberyCtrl
    }

    
}
