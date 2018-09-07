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



    public void OnRandomBuyClick()
    {

    }
    
    public void OnMagnetBuyClick()
    {
        BuyToolsArgs e = new BuyToolsArgs
        {
            itemType = ItemType.ItemMagnet,
            CoinCount = 100            
        };
        SendEvent(Consts.E_BuyTools, e);
    }

    public void OnMutiplyBuyClick()
    {
        BuyToolsArgs e = new BuyToolsArgs
        {
            itemType = ItemType.ItemMultiply,
            CoinCount = 200
        };
        SendEvent(Consts.E_BuyTools, e);
    }

    public void OnInvincibleBuyClick()
    {
        BuyToolsArgs e = new BuyToolsArgs
        {
            itemType = ItemType.ItemInvincible,
            CoinCount = 300
        };
        SendEvent(Consts.E_BuyTools, e);
    }

}
