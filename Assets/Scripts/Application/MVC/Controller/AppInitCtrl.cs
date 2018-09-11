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
        RegisterController(Consts.E_EnterScene, typeof(EnterScenesCtrl));

        RegisterController(Consts.E_ExitScene, typeof(ExitScenesCtrl));

        RegisterController(Consts.E_EndGame, typeof(EndGameCtrl));

        RegisterController(Consts.E_PauseGame, typeof(PauseGameCtrl));

        RegisterController(Consts.E_ResumeGame, typeof(ResumeGameCtrl));

        RegisterController(Consts.E_HitItem, typeof(HitItemCtrl));

        RegisterController(Consts.E_FinalShowUI, typeof(FinalShowUICtrl));

        RegisterController(Consts.E_BriberyClick, typeof(BriberyCtrl));

        RegisterController(Consts.E_ContinueGame, typeof(ContinueGameCtrl));

        RegisterController(Consts.E_BuyTools, typeof(BuyToolsCtrl));

        //shop
        RegisterController(Consts.E_BuyFootBall, typeof(FootBallBuyCtrl));
        RegisterController(Consts.E_EquipeFootBall, typeof(EquipeFootBallCtrl));
        RegisterController(Consts.E_CloseBuy, typeof(CloseBuyCtrl));
        RegisterController(Consts.E_CloseEquipe, typeof(CloseEquipeCtrl));








        //注册model
        RegisterModel(new GameModel());
        //初始化
        GameModel gm = GetModel<GameModel>();
        gm.Init();
        gm.InitShop();


    }
}
