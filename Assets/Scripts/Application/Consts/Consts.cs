using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Consts
{
    //Event名字
    public const string E_AppInit = "E_AppInit";//初始化注册

    public const string E_ExitScene = "E_ExitScene"; //退出场景 //SenceArgs
    public const string E_EnterScene = "E_EnterScene";//进入场景//SenceArgs
    public const string E_EndGame = "E_EndGame";//结束游戏
    public const string E_PauseGame = "E_PauseGame";//暂停游戏
    public const string E_ResumeGame = "E_ResumeGame";//返回游戏

    public const string E_HitItem = "E_HitItem";//更新道具

    //UI相关事件
    public const string E_UpdateDis = "E_UpdateDis";//更新距离//DistanceArgs
    public const string E_UpdateCoin = "E_UpdateCoin";//更新金币//CoinArgs
    public const string E_HitAddTime = "E_HitAddTime";//更新时间

    
   



    //Model名字
    public const string M_GameModle = "M_GameModle";

    //View名字
    public const string V_PlayerMove = "V_PlayerMove";
    public const string V_PlayerAnim = "V_PlayerAnim";

    public const string V_UIBoard = "V_UIBoard";
    public const string V_UIPause = "V_UIPause";
    public const string V_UIResume = "V_UIResume";
}

//输入枚举
public enum InputDirection
{
    NULL,
    Right,
    Left,
    Up,
    Down
}
//跑道
public enum RunWay
{
    Left=0,
    Middle,
    Right
}

//奖励物品类型
public enum ItemType
{
    ItemInvincible,
    ItemMultiply,
    ItemMagnet,
    ItemAddTime
}
