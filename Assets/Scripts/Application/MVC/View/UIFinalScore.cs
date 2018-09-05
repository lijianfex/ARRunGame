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

    public void UpdateUI(int dis,int coin,int goal,int exp,int level)
    {
        Dis_txt.text = dis.ToString();
        Coin_txt.text = coin.ToString();
        Goal_txt.text = goal.ToString();

        Score_txt.text = (coin  + dis * (goal+1)).ToString();

        //slider文字
        Exp_txt.text = exp.ToString() + "/" + (10 + level * 3).ToString();

        Exp_slider.value = exp / (float)(10 + level * 3);

        //等级
        Leve_txt.text = level.ToString() + "级";


    }

   
}
