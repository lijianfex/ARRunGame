using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
///主页UI
/// </summary>
public class UIMainMenu : View
{

    public override string Name
    {
        get
        {
            return Consts.V_UIMainMenu;
        }
    }

    public override void HandleEvent(string name, object data = null)
    {
        
    }

    public void OnShopBtnClick()
    {
        Game.Instance.Level.LoadLevel(2);
    }
}
