﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 游戏中UI界面
/// </summary>
public class UIBoard : View
{
   
    #region 事件
    #endregion

    #region 字段
    int m_Coin = 0;
    int m_Distance = 0;
    int m_GoalCount = 0;

    float m_InitStartTime;
    float m_Curtime;
    float m_SkillTime;
    GameModel m_GM;


    public Text Coin_txt;//金币
    public Text User_Coin;//用户自身的金币
    public Text Distance_txt;//距离

    public Text Timer_txt;//时间
    public Slider Timer_slider;//时间slider

    //技能时间
    public Text MagnetTime_txt;
    public Text MultiplyTime_txt;
    public Text InvincibleTime_txt;

    //技能按钮
    public Button Magnet_btn;
    public Button Multiply_btn;
    public Button Invincible_btn;

    public Text Magnetcount_txt;
    public Text Multiplycount_txt;
    public Text Invinciblecount_txt;
    //射门
    public Slider Football_slider;
    public Button Football_btn;

    IEnumerator MutiplyCor; //双倍金币协程

    IEnumerator MagnetCor;//吸铁石协程

    IEnumerator InvincibleCor;//无敌协程


    #endregion

    #region 属性
    public override string Name
    {
        get
        {
            return Consts.V_UIBoard;
        }
    }

    public int Coin
    {
        get
        {
            return m_Coin;
        }

        set
        {
            m_Coin = value;
            Coin_txt.text = value.ToString();
        }
    }

    public int Distance
    {
        get
        {
            return m_Distance;
        }

        set
        {
            m_Distance = value;
            Distance_txt.text = value.ToString() + "米";
        }
    }

    public float Curtime
    {
        get
        {
            return m_Curtime;
        }

        set
        {
            if (value <= 0)
            {
                value = 0;
                SendEvent(Consts.E_EndGame);//--->EndGameCtrl,结束游戏
                Game.Instance.Sound.PlayEffect("Se_UI_End");
            }
            else if (value > InitStartTime)
            {
                value = InitStartTime;
            }
            if(value==2)
            {
                Game.Instance.Sound.PlayEffect("Se_UI_Countdown");
            }
            m_Curtime = value;
            Timer_txt.text = value.ToString("f2") + "s";
            Timer_slider.value = value / InitStartTime;
        }
    } //在内部设置滑动条的更新显示

    public int GoalCount
    {
        get
        {
            return m_GoalCount;
        }

        set
        {
            m_GoalCount = value;
        }
    }

    public float InitStartTime
    {
        get
        {
            return m_InitStartTime;
        }

        set
        {
            m_InitStartTime = value;
        }
    }
    #endregion

    #region 方法
    //点击暂停按钮
    public void OnPauseBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        PauseArgs e = new PauseArgs
        {
            coinCount = Coin,
            distance = Distance,
            score = Coin + Distance * (GoalCount + 1)
        };
        SendEvent(Consts.E_PauseGame, e);//通知PauseGameCtrl
    }

    //更新UI
    public void UpdateUI()
    {
        ShowOrHide(m_GM.Magnet, Magnet_btn,Magnetcount_txt);
        ShowOrHide(m_GM.Multiply, Multiply_btn,Multiplycount_txt);
        ShowOrHide(m_GM.Invincible, Invincible_btn,Invinciblecount_txt);
        User_Coin.text = m_GM.Coin.ToString(); //更新贿赂后用户自身的金币数
    }

    void ShowOrHide(int i, Button btn, Text count)
    {
        if (i > 0)
        {
            btn.interactable = true;
            count.transform.parent.gameObject.SetActive(true);
            count.text = i.ToString();
            btn.transform.Find("Mask").gameObject.SetActive(false);
        }
        else
        {
            btn.interactable = false;
            count.transform.parent.gameObject.SetActive(false);
            btn.transform.Find("Mask").gameObject.SetActive(true);
        }
    }

    //双倍金币
    public void HitMutiply()
    {
        if (MutiplyCor != null)
        {
            StopCoroutine(MutiplyCor);
        }
        MutiplyCor = MutiplyCoroTime();
        StartCoroutine(MutiplyCor);
    }

    IEnumerator MutiplyCoroTime()
    {

        float timer = m_SkillTime;
        MultiplyTime_txt.transform.parent.gameObject.SetActive(true);
        while (timer > 0)
        {
            if (m_GM.IsPlay && !m_GM.IsPause)
            {
                timer -= Time.deltaTime;
                MultiplyTime_txt.text = GetTime(timer);
            }
            yield return 0;
        }
        MultiplyTime_txt.transform.parent.gameObject.SetActive(false);

    }

    //吸铁石
    public void HitMagnet()
    {
        if (MagnetCor != null)
        {
            StopCoroutine(MagnetCor);
        }
        MagnetCor = MagnetCoroTime();
        StartCoroutine(MagnetCor);
    }

    IEnumerator MagnetCoroTime()
    {

        float timer = m_SkillTime;
        MagnetTime_txt.transform.parent.gameObject.SetActive(true);
        while (timer > 0)
        {
            if (m_GM.IsPlay && !m_GM.IsPause)
            {
                timer -= Time.deltaTime;
                MagnetTime_txt.text = GetTime(timer);
            }
            yield return 0;
        }
        MagnetTime_txt.transform.parent.gameObject.SetActive(false);

    }

    //无敌状态
    public void HitInvincible()
    {
        if (InvincibleCor != null)
        {
            StopCoroutine(InvincibleCor);
        }
        InvincibleCor = InvincibleCoroutine();
        StartCoroutine(InvincibleCor);
    }

    IEnumerator InvincibleCoroutine()
    {

        float timer = m_SkillTime;
        InvincibleTime_txt.transform.parent.gameObject.SetActive(true);
        while (timer > 0)
        {
            if (m_GM.IsPlay && !m_GM.IsPause)
            {
                timer -= Time.deltaTime;
                InvincibleTime_txt.text = GetTime(timer);
            }
            yield return 0;
        }
        InvincibleTime_txt.transform.parent.gameObject.SetActive(false);
    }


    //按钮点击吸铁石
    public void OnMagnetBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        ItemArgs e = new ItemArgs
        {
            hitCount = 1,
            itemtype = ItemType.ItemMagnet
        };
        SendEvent(Consts.E_HitItem, e);//通知HitItemCtrl
    }
    //按钮点击加倍金币
    public void OnMultiplyBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        ItemArgs e = new ItemArgs
        {
            hitCount = 1,
            itemtype = ItemType.ItemMultiply
        };
        SendEvent(Consts.E_HitItem, e);//通知HitItemCtrl
    }
    //按钮点击无敌口哨
    public void OnInvincibleBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        ItemArgs e = new ItemArgs
        {
            hitCount = 1,
            itemtype = ItemType.ItemInvincible
        };
        SendEvent(Consts.E_HitItem, e);//通知HitItemCtrl
    }

   
    /// <summary>
    /// 开启射门按钮，并开始倒计时
    /// </summary>
    void ShowGoalClick()
    {
        StartCoroutine(ShotGoalCor());
    }
    IEnumerator ShotGoalCor()
    {
        Football_btn.interactable = true;
        Football_slider.value = 1f;
        float timer = 1f;
        while (timer > 0)
        {
            if (m_GM.IsPlay && !m_GM.IsPause)//处理在射球时暂停
            {
                timer -= Time.deltaTime;
                Football_slider.value = timer / 1f;
            }
            yield return 0;
        }
        Football_btn.interactable = false;
        Football_slider.value = 0f;
    }

    /// <summary>
    /// 点击射门按钮事件
    /// </summary>
    public void OnFootBallBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        SendEvent(Consts.E_FootShotClick);//通知PlayerMove，射球
        Football_slider.value = 0f;
    }

    /// <summary>
    /// UIBorad 界面隐藏
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// UIBorad 界面显示
    /// </summary>
    public void Show()
    {
        gameObject.SetActive(true);
    }

    #endregion

    #region Unity回调
    private void Awake()
    {
        
        m_GM = GetModel<GameModel>();
        InitStartTime= m_GM.StartTime;
        Curtime =m_GM.StartTime;
        m_SkillTime = m_GM.SkillTime;
        UpdateUI();
        
    }


    /// <summary>
    /// 更新时间计时
    /// </summary>
    private void Update()
    {
        if (m_GM.IsPlay && !m_GM.IsPause)
        {
            Curtime -= Time.deltaTime; //更新时间计时
        }
    }
    #endregion

    #region 事件回调
    public override void RegisterAttentionEvent()
    {
        AttentionList.Add(Consts.E_UpdateDis); //更新距离
        AttentionList.Add(Consts.E_UpdateCoin); //更新金币
        AttentionList.Add(Consts.E_HitAddTime); //更新加时间
        AttentionList.Add(Consts.E_HitGoalTrigger); //触碰到可以射门时的检测触发
        AttentionList.Add(Consts.E_ShotGoal);
    }

    //处理消息
    public override void HandleEvent(string name, object data = null)
    {
        switch (name)
        {
            case Consts.E_UpdateDis:
                DistanceArgs Disargs = data as DistanceArgs;
                Distance = Disargs.Distance;
                break;
            case Consts.E_UpdateCoin:
                CoinArgs c = data as CoinArgs;
                Coin += c.CoinCount;
                break;
            case Consts.E_HitAddTime:
                Curtime += 10f;
                break;
            case Consts.E_HitGoalTrigger:
                ShowGoalClick();
                break;
            case Consts.E_ShotGoal:
                GoalCount += 1;                
                break;
            default:
                break;
        }

    }

    #endregion

    #region 帮助方法
    //将时间转为string
    string GetTime(float time)
    {
        return ((int)time + 1).ToString();
    }



    #endregion
}