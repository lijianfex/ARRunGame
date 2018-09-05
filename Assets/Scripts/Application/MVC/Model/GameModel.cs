using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : Model
{
    #region 常量
    #endregion

    #region 事件
    #endregion

    #region 字段
    bool isPlay=true;//游戏是否进行
    bool isPause=false;//是否暂停
    int skillTime = 5;//技能时间

    int m_Level;
    int m_Exp;

    int m_Magnet;
    int m_Multiply;
    int m_Invincible;
    #endregion

    #region 属性
    public override string Name
    {
        get
        {
            return Consts.M_GameModle;
        }
    }

    public bool IsPlay
    {
        get
        {
            return isPlay;
        }

        set
        {
            isPlay = value;
        }
    }

    public bool IsPause
    {
        get
        {
            return isPause;
        }

        set
        {
            isPause = value;
        }
    }

    public int SkillTime
    {
        get
        {
            return skillTime;
        }

        set
        {
            skillTime = value;
        }
    }

    public int Magnet
    {
        get
        {
            return m_Magnet;
        }

        set
        {
            m_Magnet = value;
        }
    }

    public int Multiply
    {
        get
        {
            return m_Multiply;
        }

        set
        {
            m_Multiply = value;
        }
    }

    public int Invincible
    {
        get
        {
            return m_Invincible;
        }

        set
        {
            m_Invincible = value;
        }
    }

    public int Level
    {
        get
        {
            return m_Level;
        }

        set
        {
            m_Level = value;
        }
    }

    public int Exp
    {
        get
        {
            return m_Exp;
        }

        set
        {
            while(value > 10 + (Level * 3))
            {
                //消耗经验
                value -= 10 + (Level * 3);
                //升级
                Level++;
            }
            m_Exp = value;
        }
    }


    #endregion

    #region 方法
    //初始化Model
    public void Init()
    {
        m_Magnet = 0;
        m_Multiply = 0;
        m_Invincible = 0;
        skillTime = 5;
        m_Exp = 0;
        m_Level = 1;        
    }

    #endregion

    #region Unity回调
    #endregion

    #region 事件回调
    #endregion

    #region 帮助方法
    #endregion


}
