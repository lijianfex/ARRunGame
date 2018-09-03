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

    #region 事件
    #endregion

    #region 字段
    int m_Coin = 0;
    int m_Distance = 0;


    public Text Coin_txt;
    public Text Distance_txt;


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
    #endregion

    #region 方法
    #endregion

    #region Unity回调
    #endregion

    #region 事件回调
    public override void RegisterAttentionEvent()
    {
        AttentionList.Add(Consts.E_UpdataDis);
    }

    public override void HandleEvent(string name, object data = null)
    {
        switch (name)
        {
            case Consts.E_UpdataDis:
                DistanceArgs args = data as DistanceArgs;
                Distance = args.Distance;
                break;
            default:
                break;
        }

    }
    
    #endregion

    #region 帮助方法
    #endregion
}