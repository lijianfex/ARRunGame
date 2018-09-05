using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 返回游戏倒计时UI
/// </summary>
public class UIResume : View
{
    public Image imgTime;
    public Sprite[] sprites;

    public override string Name
    {
        get
        {
            return Consts.V_UIResume;
        }
    }

    public override void HandleEvent(string name, object data = null)
    {
        
    }

    /// <summary>
    /// 开始计时
    /// </summary>
    public void StartCount()
    {
        Show();
        StartCoroutine(StartCountCor());
    }

    IEnumerator StartCountCor()
    {
        int i = sprites.Length;
        while(i>0)
        {
            imgTime.sprite = sprites[i - 1];
            i--;
            yield return new WaitForSeconds(1);
            if(i<=0)
            {
                break;
            }
        }
        Hide();

        //TODO
        SendEvent(Consts.E_ContinueGame);//---->ContinueGameCtrl
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

}
