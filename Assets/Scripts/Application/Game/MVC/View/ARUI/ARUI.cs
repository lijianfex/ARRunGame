using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARUI : View
{
    public override string Name
    {
        get
        {
            return Consts.V_ARUI;
        }
    }

    public void OnImageTargetClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        Game.Instance.Level.LoadLevel(Levels.ARImage);
        
    }

    public void OnSurfaceTargetClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        Game.Instance.Level.LoadLevel(Levels.ARSurface);


    }
    public void OnObjectTargetClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        Game.Instance.Level.LoadLevel(Levels.ARObject);


    }

    public void OnARExit()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        Game.Instance.Level.LoadLevel(Levels.MainMenu);
        
    }

    public override void HandleEvent(string name, object data = null)
    {
        
    }
}
