using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 初始化注册类
/// </summary>
public class AppInitCtrl : Controller
{
    public override void Execute(object data = null)
    {
        //注册Controller
# region    注册Controller
        RegisterController(Consts.E_EnterScene, typeof(EnterScenesCtrl)); //进入场景

        RegisterController(Consts.E_ExitScene, typeof(ExitScenesCtrl)); //退出场景

        RegisterController(Consts.E_EndGame, typeof(EndGameCtrl)); //结束游戏

        RegisterController(Consts.E_PauseGame, typeof(PauseGameCtrl));//暂停游戏

        RegisterController(Consts.E_ResumeGame, typeof(ResumeGameCtrl)); //恢复游戏

        RegisterController(Consts.E_HitItem, typeof(HitItemCtrl));//碰到物体

        RegisterController(Consts.E_FinalShowUI, typeof(FinalShowUICtrl));//结算UI

        RegisterController(Consts.E_BriberyClick, typeof(BriberyCtrl));//贿赂

        RegisterController(Consts.E_ContinueGame, typeof(ContinueGameCtrl));//继续游戏

        RegisterController(Consts.E_BuyTools, typeof(BuyToolsCtrl));//道具购买

        //shop
        RegisterController(Consts.E_BuyFootBall, typeof(FootBallBuyCtrl));
        RegisterController(Consts.E_EquipeFootBall, typeof(EquipeFootBallCtrl));
        RegisterController(Consts.E_CloseBuy, typeof(CloseBuyCtrl));
        RegisterController(Consts.E_CloseEquipe, typeof(CloseEquipeCtrl));
        RegisterController(Consts.E_HeadBuy, typeof(HeadBuyCtrl));
        RegisterController(Consts.E_HeadEquipe, typeof(HeadEquipeCtrl));
        RegisterController(Consts.E_ShoseBuy, typeof(ShoseBuyCtrl));
        RegisterController(Consts.E_ShoseEquipe, typeof(ShoseEquipeCtrl));

        //AR
        //---imageTarget
        RegisterController(Consts.E_AR_FootBallGet, typeof(ARFootBallGetCtrl));
        RegisterController(Consts.E_AR_FootBallEquipe, typeof(ARFootBallEquipeCtrl));
        RegisterController(Consts.E_AR_CloseGet, typeof(ARCloseGetCtrl));
        RegisterController(Consts.E_AR_CloseEquipe, typeof(ARCloseEquipeCtrl));
        RegisterController(Consts.E_AR_ShoseGet, typeof(ARShoseGetCtrl));
        RegisterController(Consts.E_AR_ShoseEquipe, typeof(ARShoseEquipeCtrl));
        RegisterController(Consts.E_AR_HeadGet, typeof(ARHeadGetCtrl));
        RegisterController(Consts.E_AR_HeadEquipe, typeof(ARHeadEquipeCtrl));
        RegisterController(Consts.E_AR_VideoPlayEnd, typeof(ARVideoPlayEndCtrl));

        //---otherTagert
        RegisterController(Consts.E_AR_ToolsGet, typeof(ARToolsGetCtrl));



        #endregion






        //注册model
        RegisterModel(new GameModel());
        //初始化
        GameModel gm = GetModel<GameModel>();
        gm.Init();
        


    }
}
