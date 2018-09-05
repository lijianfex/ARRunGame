using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFinalScore : View
{
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
}
