using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 结算界面
/// </summary>
public class UIFinalScore : View
{
    public Text Score_txt;

    public Text Goal_txt;
    public Text Dis_txt;
    public Text Coin_txt;

    public Text Leve_txt;
    public Text Exp_txt;
    public Slider Exp_slider;


    public override string Name
    {
        get
        {
            return Consts.V_UIFinalScore;
        }
    }

    public override void HandleEvent(string name, object data = null)
    {

    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void UpdateUI(int dis, int coin, int goal, int exp, int level)
    {
        Dis_txt.text = dis.ToString();
        Coin_txt.text = coin.ToString();
        Goal_txt.text = goal.ToString();

        Score_txt.text = (coin + dis * (goal + 1)).ToString();

        //slider文字
        Exp_txt.text = exp.ToString() + "/" + (500 + level * 100).ToString();

        Exp_slider.value = exp / (float)(500 + level * 100);

        //等级
        Leve_txt.text = level.ToString() + "级";

    }

    //重新游戏
    public void OnReplayGameClick()
    {
        Game.Instance.Level.LoadLevel(Levels.Game);
    }

    //回到主页
    public void OnMainMenuBtnClick()
    {
        Game.Instance.Level.LoadLevel(Levels.MainMenu);
    }

    //回到商城
    public void OnShopBtnClick()
    {
        Game.Instance.Level.LoadLevel(Levels.Shop);
    }


}
