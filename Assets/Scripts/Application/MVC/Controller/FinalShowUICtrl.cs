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
        board.Hide();
        dead.Hide();
        finalScore.Show();

    }
}
