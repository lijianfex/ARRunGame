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
    //结算事件
    public const string E_FinalShowUI = "E_FinalShowUI";
    //贿赂
    public const string E_BriberyClick = "E_BriberyClick";

    //继续游戏
    public const string E_ContinueGame = "E_ContinueGame";
    //购买道具
    public const string E_BuyTools = "E_BuyTools";

    //-------shop-------

    public const string E_BuyFootBall = "E_BuyFootBall";//购买足球    
    public const string E_EquipeFootBall = "E_EquipeFootBall";//装备足球
    public const string E_CloseBuy = "E_CloseBuy";
    public const string E_CloseEquipe = "E_CloseEquipe";
    public const string E_HeadBuy = "E_HeadBuy";
    public const string E_HeadEquipe = "E_HeadEquipe";
    public const string E_ShoseBuy = "E_ShoseBuy";
    public const string E_ShoseEquipe = "E_ShoseEquipe";


    //---------AR--------------------------------------------------
    //AR ImageTarget
    public const string E_AR_FootBallGet = "E_AR_FootBallGet";//AR获得足球    
    public const string E_AR_FootBallEquipe = "E_AR_FootBallEquipe";//AR装备足球
    public const string E_AR_CloseGet = "E_AR_CloseGet";
    public const string E_AR_CloseEquipe = "E_AR_CloseEquipe";
    public const string E_AR_HeadGet = "E_AR_HeadGet";
    public const string E_AR_HeadEquipe = "E_AR_HeadEquipe";
    public const string E_AR_ShoseGet = "E_AR_ShoseGet";
    public const string E_AR_ShoseEquipe = "E_AR_ShoseEquipe";
    public const string E_AR_VideoPlayEnd = "E_AR_VideoPlayEnd";

    //OtherTarget
    public const string E_AR_ToolsGet = "E_AR_ToolsGet";




    //UIBoard相关事件
    public const string E_UpdateDis = "E_UpdateDis";//更新距离//DistanceArgs
    public const string E_UpdateCoin = "E_UpdateCoin";//更新金币//CoinArgs
    public const string E_HitAddTime = "E_HitAddTime";//更新时间

    //射门相关
    public const string E_HitGoalTrigger = "E_HitGoalTrigger";//可以射门
    public const string E_FootShotClick = "E_FootShotClick";//点击射门
    public const string E_ShotGoal = "E_ShotGoal";//进球 GoalCount+1







    //Model名字
    public const string M_GameModle = "M_GameModle";

    //View名字
    public const string V_PlayerMove = "V_PlayerMove";
    public const string V_PlayerAnim = "V_PlayerAnim";

    public const string V_UIBoard = "V_UIBoard";
    public const string V_UIPause = "V_UIPause";
    public const string V_UIResume = "V_UIResume";
    public const string V_UIDead = "V_UIDead";
    public const string V_UIFinalScore = "V_UIFinalScore";
    public const string V_UIBuyTools = "V_UIBuyTools";
    public const string V_UIMainMenu = "V_UIMainMenu";
    public const string V_UIShop = "V_UIShop";

    public const string V_ARUI = "V_ARUI"; //AR选择页
    public const string V_ARImageUI = "V_ARImageUI"; //AR 图片识别
    public const string V_ARSurfaceUI = "V_ARSurfaceUI"; //AR 表面识别
    public const string V_ARObjectUI = "V_ARObjectUI";//AR 模型识别
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
    Left = 0,
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

//道具状态
public enum ItemState
{
    UnBuy,
    Buy,
    Equiep
}

public static class Levels
{
    public const int MainMenu = 1;
    public const int Shop = 2;
    public const int BuyTools = 3;
    public const int Game = 4;
    public const int AR = 5;
    public const int ARImage = 6;
    public const int ARSurface = 7;
    public const int ARObject = 8;
}

