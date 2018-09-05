using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 显示FinalUI
/// </summary>
public class FinalShowUICtrl : Controller
{
    public override void Execute(object data = null)
    {
        UIBoard board = GetView<UIBoard>();
        UIFinalScore finalScore = GetView<UIFinalScore>();
        UIDead dead = GetView<UIDead>();

        GameModel gm = GetModel<GameModel>();

        board.Hide();
        dead.Hide();
        finalScore.Show();

        //1.更新Exp
        gm.Exp += board.Coin + board.Distance * (board.GoalCount + 1);
        //2.更新UI
        finalScore.UpdateUI(board.Distance, board.Coin, board.GoalCount,gm.Exp,gm.Level);

    }
}
