using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 商场界面
/// </summary>
public class UIShop : View
{
    public override string Name
    {
        get
        {
            return Consts.V_UIShop;
        }
    }

    public override void HandleEvent(string name, object data = null)
    {
        
    }
}
