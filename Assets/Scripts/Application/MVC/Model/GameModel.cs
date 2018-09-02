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
    #endregion

    #region 方法
    #endregion

    #region Unity回调
    #endregion

    #region 事件回调
    #endregion

    #region 帮助方法
    #endregion


}
