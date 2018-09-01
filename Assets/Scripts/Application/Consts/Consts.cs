using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Consts
{
    //Event名字
    public const string E_AppInit = "E_AppInit";//初始化注册

    public const string E_ExitScene = "E_ExitScene"; //退出场景
    public const string E_EnterScene = "E_EnterScene";//进入场景
    public const string E_EndGame = "E_EndGame";//结束游戏





    //Model名字
    public const string M_GameModle = "M_GameModle";

    //View名字
    public const string V_PlayerMove = "V_PlayerMove";
    public const string V_PlayerAnim = "V_PlayerAnim";
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
