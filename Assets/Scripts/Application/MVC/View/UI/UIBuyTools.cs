using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuyTools : View
{
    public Text MagnetCount_txt;
    public Text MultiplyCount_txt;
    public Text InvicinbleCount_txt;
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
        ShowOrHide(gm.Magnet, MagnetCount_txt);
        ShowOrHide(gm.Multiply, MultiplyCount_txt);
        ShowOrHide(gm.Invincible, InvicinbleCount_txt);
    }

    void ShowOrHide(int i, Text txt)
    {
        if (i > 0)
        {
            txt.transform.parent.gameObject.SetActive(true);
            txt.text = i.ToString();
        }
        else
        {
            txt.transform.parent.gameObject.SetActive(true);
            txt.text = i.ToString();
        }
    }

    //点击随机购买
    public void OnRandomBuyClick()
    {
        int i = Random.Range(0, 3);
        BuyToolsArgs e = new BuyToolsArgs();
        e.CoinCount = 300;
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
        BuyToolsArgs e = new BuyToolsArgs
        {
            itemType = ItemType.ItemInvincible,
            CoinCount = 300
        };
        SendEvent(Consts.E_BuyTools, e);
    }

    //点击开始游戏按钮
    public void OnStartGameClicK()
    {
        Game.Instance.Level.LoadLevel(4);
    }

    //返回上一场景
    public void OnReturnBtnClick()
    {
        Game.Instance.Level.LoadLevel(2);
    }

}
