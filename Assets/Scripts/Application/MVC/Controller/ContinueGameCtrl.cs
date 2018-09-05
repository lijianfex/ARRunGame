using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 继续游戏
/// </summary>
public class ContinueGameCtrl : Controller
{
    public override void Execute(object data = null)
    {
        GameModel gm = GetModel<GameModel>();        
        UIBoard board = GetView<UIBoard>();
        if(board.Curtime<0.1f)
        {
            board.Curtime += 20f;
        }
        gm.IsPause = false;
        gm.IsPlay = true;
    }
}
