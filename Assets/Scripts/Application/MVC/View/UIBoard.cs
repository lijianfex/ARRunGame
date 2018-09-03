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
    float m_Curtime;
    GameModel m_GM;


    public Text Coin_txt;
    public Text Distance_txt;

    public Text Timer_txt;

    public Slider Timer_slider;


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
            Distance_txt.text = value.ToString()+"米";
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
            if(value<=0)
            {
                value = 0;
                SendEvent(Consts.E_EndGame);
            }
            else if(value>StartTime)
            {
                value = StartTime;
            }
            m_Curtime = value;
            Timer_txt.text = value.ToString("f2")+"s";
            Timer_slider.value = value / StartTime;
        }
    }
    #endregion

    #region 方法
    #endregion

    #region Unity回调
    private void Awake()
    {
        Curtime = StartTime;
        m_GM = GetModel<GameModel>();
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
    }

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
            default:
                break;
        }

    }
    
    #endregion

    #region 帮助方法
    #endregion
}