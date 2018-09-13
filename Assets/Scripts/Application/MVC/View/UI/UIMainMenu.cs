using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
///主页UI
/// </summary>
public class UIMainMenu : View
{
    public SkinnedMeshRenderer ClothRender;
    public MeshRenderer BallRender;


    GameModel gm;

    private void Awake()
    {
        gm = GetModel<GameModel>();
        ClothRender.material.mainTexture = Game.Instance.Data.GetCloseData(gm.EquipeClothIndex).texture;
        BallRender.material = Game.Instance.Data.GetFootballData(gm.EquipeBallIndex).material;
        
    }

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
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        Game.Instance.Level.LoadLevel(Levels.Shop);
    }

    public void OnPlayBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        Game.Instance.Level.LoadLevel(Levels.BuyTools);
    }
}
