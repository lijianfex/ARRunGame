using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuyTools : View
{
    public Text MagnetCount_txt;
    public Text MultiplyCount_txt;
    public Text InvicinbleCount_txt;

    public Button MagnetCancle_btn;
    public Button MultiplyCancle_btn;
    public Button InvicinbleCancle_btn;

    public Text CoinCount_txt;

    public SkinnedMeshRenderer ClothRender;
    public MeshRenderer BallRender;

    GameModel gm;

    public override string Name
    {
        get
        {
            return Consts.V_UIBuyTools;
        }
    }

    public override void HandleEvent(string name, object data = null)
    {

    }

    private void Awake()
    {
        gm = GetModel<GameModel>();

        //更新皮肤与球
        ClothRender.material.mainTexture = Game.Instance.Data.GetCloseData(gm.EquipeClothIndex).texture;
        BallRender.material = Game.Instance.Data.GetFootballData(gm.EquipeBallIndex).material;

        //更新ui
        UpdateUI();
    }

    //更新UI
    public void UpdateUI()
    {
        CoinCount_txt.text = gm.Coin.ToString();
        ShowOrHide(gm.Magnet, MagnetCount_txt,MagnetCancle_btn);
        ShowOrHide(gm.Multiply, MultiplyCount_txt,MultiplyCancle_btn);
        ShowOrHide(gm.Invincible, InvicinbleCount_txt,InvicinbleCancle_btn);
    }

    void ShowOrHide(int i, Text txt,Button btn)
    {
        if (i > 0)
        {
            txt.transform.parent.gameObject.SetActive(true);
            btn.interactable = true;
            txt.text = i.ToString();
        }
        else
        {
            txt.transform.parent.gameObject.SetActive(false);
            btn.interactable = false;
            
        }
    }

    //点击随机购买
    public void OnRandomBuyClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        int i = Random.Range(0, 3);
        BuyToolsArgs e = new BuyToolsArgs();
        e.CoinCount = 200;
        switch (i)
        {
            case 0:
                e.itemType = ItemType.ItemInvincible;
                break;
            case 1:
                e.itemType = ItemType.ItemMultiply;
                break;
            case 2:
                e.itemType = ItemType.ItemMagnet;
                break;
            default:
                break;
        }
        SendEvent(Consts.E_BuyTools, e);
    }

    //点击吸铁石购买
    public void OnMagnetBuyClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        BuyToolsArgs e = new BuyToolsArgs
        {
            itemType = ItemType.ItemMagnet,
            CoinCount = 100
        };
        SendEvent(Consts.E_BuyTools, e);
    }

    //点击双倍金币购买
    public void OnMutiplyBuyClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        BuyToolsArgs e = new BuyToolsArgs
        {
            itemType = ItemType.ItemMultiply,
            CoinCount = 200
        };
        SendEvent(Consts.E_BuyTools, e);
    }
    //点击无敌状态购买
    public void OnInvincibleBuyClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        BuyToolsArgs e = new BuyToolsArgs
        {
            itemType = ItemType.ItemInvincible,
            CoinCount = 300
        };
        SendEvent(Consts.E_BuyTools, e);
    }

    //点击吸铁石取消一个
    public void OnMagnetCancleClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        BuyToolsArgs e = new BuyToolsArgs
        {
            itemType = ItemType.ItemMagnet,
            CoinCount = -100
        };
        SendEvent(Consts.E_BuyTools, e);
    }

    //点击双倍金币取消一个
    public void OnMutiplyCancleClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        BuyToolsArgs e = new BuyToolsArgs
        {
            itemType = ItemType.ItemMultiply,
            CoinCount = -200
        };
        SendEvent(Consts.E_BuyTools, e);
    }
    //点击无敌状态取消一个
    public void OnInvincibleCancleClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        BuyToolsArgs e = new BuyToolsArgs
        {
            itemType = ItemType.ItemInvincible,
            CoinCount = -300
        };
        SendEvent(Consts.E_BuyTools, e);
    }

    //点击开始游戏按钮
    public void OnStartGameClicK()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        Game.Instance.Level.LoadLevel(Levels.Game);
    }

    //返回上一场景
    public void OnReturnBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        if (gm.LastSenceIndex == 4)
            gm.LastSenceIndex = 2;
        Game.Instance.Level.LoadLevel(gm.LastSenceIndex);
    }

    //返回主页
    public void OnMainMenuBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        Game.Instance.Level.LoadLevel(Levels.MainMenu);
    }

}
