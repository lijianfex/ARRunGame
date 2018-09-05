using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDead : View
{
    public override string Name
    {
        get
        {
            return Consts.V_UIDead;
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

    //鼠标点击关闭
    public void OnCloseBtnClick()
    {
        SendEvent(Consts.E_FinalShowUI);
    }
}
