using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : Model
{
    #region 常量
    const int InitCoin = 2000;
    #endregion

    #region 事件
    #endregion

    #region 字段
    bool isPlay = true;//游戏是否进行
    bool isPause = false;//是否暂停
    int skillTime = 5;//技能时间

    int m_Level;
    int m_Exp;

    int m_Magnet;
    int m_Multiply;
    int m_Invincible;

    int m_Coin;

    List<FootballInfo> footballInfoList;
    List<CloseInfo> closeInfoList;
    List<HeadInfo> headInfoList;
    List<ShoseInfo> shoseInfoList;

    int m_EquipeBallIndex;
    int m_EquipeClothIndex;
    int m_EquipeHeadIndex;
    int m_EquipeShoseIndex;

    int m_ShotQulity;//射门精度
    int m_Shot;//射门力量
    int m_SpeedAdd;//加速能力




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
            while (value > 500 + (Level * 100))
            {
                //消耗经验
                value -= 500 + (Level * 100);
                //升级
                Level++;
            }
            m_Exp = value;
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
        }
    }


    public List<FootballInfo> FootballInfoList
    {
        get
        {
            return footballInfoList;
        }

        set
        {
            footballInfoList = value;
        }
    }

    public int ShotQulity
    {
        get
        {
            return m_ShotQulity;
        }

        set
        {
            m_ShotQulity = value;
        }
    }

    public int Shot
    {
        get
        {
            return m_Shot;
        }

        set
        {
            m_Shot = value;
        }
    }

    public int SpeedAdd
    {
        get
        {
            return m_SpeedAdd;
        }

        set
        {
            m_SpeedAdd = value;
        }
    }

    public List<CloseInfo> CloseInfoList
    {
        get
        {
            return closeInfoList;
        }

        set
        {
            closeInfoList = value;
        }
    }

    public int EquipeBallIndex
    {
        get
        {
            return GetEquipeBallIndex();
        }

    }

    public int EquipeClothIndex
    {
        get
        {
            return GetEquipeClothIndex();
        }

    }

    public List<HeadInfo> HeadInfoList
    {
        get
        {
            return headInfoList;
        }

        set
        {
            headInfoList = value;
        }
    }

    public int EquipeHeadIndex
    {
        get
        {
            return GetEquipeHeadIndex();
        }


    }

    public List<ShoseInfo> ShoseInfoList
    {
        get
        {
            return shoseInfoList;
        }

        set
        {
            shoseInfoList = value;
        }
    }

    public int EquipeShoseIndex
    {
        get
        {
            return GetEquipeShoseIndex();
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
        m_Coin = InitCoin;
       
        InitShop();
    }

    //初始化商城
    public void InitShop()
    {
        InitFootInfo();
        InitCloseInfo();
        InitHeadInfo();
        InitShoseInfo();
    }

    //花钱
    public bool GetMoney(int count)
    {
        if (count <= Coin)
        {
            Coin -= count;
            return true;
        }
        return false;
    }


    #endregion

    #region Unity回调
    #endregion

    #region 事件回调
    #endregion

    #region 帮助方法


    //获得已装备的足球index
    int GetEquipeBallIndex()
    {
        int i = 0;
        foreach (FootballInfo info in FootballInfoList)
        {
            if (info.State == ItemState.Equiep)
            {
                i = info.Index;
            }
        }
        return i;
    }

    //获得已装备的衣服index
    int GetEquipeClothIndex()
    {
        int i = 0;
        foreach (CloseInfo info in CloseInfoList)
        {
            if (info.State == ItemState.Equiep)
            {
                i = info.Index;
            }
        }
        return i;
    }

    //获得已装备的头像
    int GetEquipeHeadIndex()
    {
        int i = 0;
        foreach (HeadInfo info in HeadInfoList)
        {
            if (info.State == ItemState.Equiep)
            {
                i = info.Index;
            }
        }
        return i;
    }

    //获得已装备的鞋子
    int GetEquipeShoseIndex()
    {
        int i = 0;
        foreach (ShoseInfo info in ShoseInfoList)
        {
            if (info.State == ItemState.Equiep)
            {
                i = info.Index;
            }
        }
        return i;
    }



    //初始化足球
    void InitFootInfo()
    {
        FootballInfoList = new List<FootballInfo>();
        FootballInfoList.Add(new FootballInfo(0, ItemState.Equiep));
        FootballInfoList.Add(new FootballInfo(1, ItemState.Buy));
        FootballInfoList.Add(new FootballInfo(2, ItemState.UnBuy));
    }
    //初始化衣服
    void InitCloseInfo()
    {
        CloseInfoList = new List<CloseInfo>();
        CloseInfoList.Add(new CloseInfo(0, ItemState.Equiep));
        CloseInfoList.Add(new CloseInfo(1, ItemState.Buy));
        CloseInfoList.Add(new CloseInfo(2, ItemState.UnBuy));
    }
    //初始化头像
    void InitHeadInfo()
    {
        HeadInfoList = new List<HeadInfo>();
        HeadInfoList.Add(new HeadInfo(0, ItemState.Equiep));
        HeadInfoList.Add(new HeadInfo(1, ItemState.Buy));
        HeadInfoList.Add(new HeadInfo(2, ItemState.UnBuy));
    }
    //初始化鞋子
    void InitShoseInfo()
    {
        ShoseInfoList = new List<ShoseInfo>();
        ShoseInfoList.Add(new ShoseInfo(0, ItemState.Equiep));
        ShoseInfoList.Add(new ShoseInfo(1, ItemState.Buy));
        ShoseInfoList.Add(new ShoseInfo(2, ItemState.UnBuy));
    }
    #endregion


}
