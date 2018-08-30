using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Consts
{
    //Event名字
    public const string E_ExitScene = "E_ExitScene";
    public const string E_EnterScene = "E_EnterScene";

    public const string E_StartUp = "E_StartUp";

    //View名字
    public const string V_PlayerMove = "V_PlayerMove";

    //Model名字


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
