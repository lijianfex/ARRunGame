using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 游戏中UI界面
/// </summary>
public class UIBoard : View
{
    #region 常量
    #endregion
    private const float StartTime = 50f;
    #region 事件
    #endregion

    #region 字段
    int m_Coin = 0;
    int m_Distance = 0;
    int m_GoalCount = 0;
    float m_Curtime;
    float m_SkillTime;
    GameModel m_GM;


    public Text Coin_txt;//金币
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
            else if (value > StartTime)
            {
                value = StartTime;
            }
            m_Curtime = value;
            Timer_txt.text = value.ToString("f2") + "s";
            Timer_slider.value = value / StartTime;
        }
    }

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
    #endregion

    #region 方法
    //点击暂停按钮
    public void OnPauseBtnClick()
    {
        PauseArgs e = new PauseArgs
        {
            coinCount = Coin,
            distance = Distance,
            score = Coin * 3 + Distance + GoalCount * 30
        };
        SendEvent(Consts.E_PauseGame, e);//通知PauseGameCtrl
    }

    //更新UI
    public void UpdateUI()
    {
        ShowOrHide(m_GM.Magnet, Magnet_btn);
        ShowOrHide(m_GM.Multiply, Multiply_btn);
        ShowOrHide(m_GM.Invincible, Invincible_btn);
    }

    void ShowOrHide(int i, Button btn)
    {
        if (i > 0)
        {
            btn.interactable = true;
            btn.transform.Find("Mask").gameObject.SetActive(false);
        }
        else
        {
            btn.interactable = false;
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
        ItemArgs e = new ItemArgs
        {
            hitCount = 1,
            itemtype = ItemType.ItemInvincible
        };
        SendEvent(Consts.E_HitItem, e);//通知HitItemCtrl
    }

    //射门
    void ShowGoalClick()
    {
        StartCoroutine(ShotGoalCor());
    }

    IEnumerator ShotGoalCor()
    {
        Football_btn.interactable = true;
        Football_slider.value = 1f;
        float timer = 1f;
        while (timer > 0 )
        {
            if(m_GM.IsPlay && !m_GM.IsPause)//处理在射球时暂停
            {
                timer -= Time.deltaTime;
                Football_slider.value = timer / 1f;
            }            
            yield return 0;
        }
        Football_btn.interactable = false;
        Football_slider.value = 0f;
    }

    public void OnFootBallBtnClick()
    {
        SendEvent(Consts.E_FootShotClick);//通知PlayerMove，射球
        Football_slider.value = 0f;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    #endregion

    #region Unity回调
    private void Awake()
    {
        Curtime = StartTime;
        m_GM = GetModel<GameModel>();
        UpdateUI();
        m_SkillTime = m_GM.SkillTime;
    }

    private void Update()
    {
        if (m_GM.IsPlay && !m_GM.IsPause)
        {
            Curtime -= Time.deltaTime;
        }
    }
    #endregion

    #region 事件回调
    public override void RegisterAttentionEvent()
    {
        AttentionList.Add(Consts.E_UpdateDis);
        AttentionList.Add(Consts.E_UpdateCoin);
        AttentionList.Add(Consts.E_HitAddTime);
        AttentionList.Add(Consts.E_HitGoalTrigger);
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
                print("进了：" + GoalCount);
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