using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 商场界面
/// </summary>
public class UIShop : View
{
    //--资源图
    public Sprite SpUnBuy;
    public Sprite SpBuy;
    public Sprite SpEquipe;
    public Sprite spBuyBtn;
    public Sprite spEquiepeBtn;

    //-----金币----
    public Text Coin_txt;//金币

    //---------------------------------------------
    public Image FootballEquipImg;//足球已装备图

    public MeshRenderer FootballMesh;//足球

    public List<Toggle> FootballTogList;

    public List<Image> FootballStateList;

    public List<Text> FootballCoinTextList;

    public Button FootBallBuyBtn;
    


    GameModel gm;
    int selectIndex;


    private void Awake()
    {
        gm = GetModel<GameModel>();
        UpdateUI();
    }

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

    public void OnReturnClick()
    {
        Game.Instance.Level.LoadLevel(3);
    }

    public void UpdateUI()
    {
        Coin_txt.text = gm.Coin.ToString();
        UpdateFootballUI();
    }

    //足球相关更新
    public void UpdateFootballUI()
    {
        
        foreach (FootballInfo info in gm.FootballInfoList)
        {
            //更新足球已装备图,与选中Toggle
            if (info.State==ItemState.Equiep)
            {
                FootballEquipImg.overrideSprite = Game.Instance.Data.GetFootballData(info.Index).sprite;
                FootballTogList[info.Index].isOn = true;
                FootBallBuyBtnUpdate(info.Index);//购买按钮
                FootballMesh.material= Game.Instance.Data.GetFootballData(info.Index).material;
            }
            switch (info.State)
            {
                case ItemState.UnBuy:
                    FootballStateList[info.Index].overrideSprite = SpUnBuy;                    
                    break;
                case ItemState.Buy:
                    FootballStateList[info.Index].overrideSprite = SpBuy;
                    break;
                case ItemState.Equiep:
                    FootballStateList[info.Index].overrideSprite = SpEquipe;
                    break;
            }
            FootballCoinTextList[info.Index].text = Game.Instance.Data.GetFootballData(info.Index).coin.ToString();

        }
    }


    //足球Toggle点击
    public void OnFootball1Click()
    {

        FootBallBuyBtnUpdate(0);
        selectIndex = 0;
    }

    public void OnFootball2Click()
    {

        FootBallBuyBtnUpdate(1);
        selectIndex = 1;

    }
    public void OnFootball3Click()
    {

        FootBallBuyBtnUpdate(2);
        selectIndex = 2;

    }

    private void FootBallBuyBtnUpdate(int index)
    {
        switch (gm.FootballInfoList[index].State)
        {
            case ItemState.UnBuy:
                FootBallBuyBtn.gameObject.SetActive(true);
                FootBallBuyBtn.GetComponent<Image>().overrideSprite = spBuyBtn;
                break;
            case ItemState.Buy:
                FootBallBuyBtn.gameObject.SetActive(true);
                FootBallBuyBtn.GetComponent<Image>().overrideSprite = spEquiepeBtn;
                break;
            case ItemState.Equiep:
                FootBallBuyBtn.gameObject.SetActive(false);
                break;
        }
    }

    //足球购买点击
    public void OnFootBallBuyBtnClick()
    {
        switch (gm.FootballInfoList[selectIndex].State)
        {
            case ItemState.UnBuy:
                //TODO发消息购买
                Debug.Log("购买");
                FootBallArgs e = new FootBallArgs
                {
                    index = selectIndex,
                    coin = Game.Instance.Data.GetFootballData(selectIndex).coin,
                    state=ItemState.Buy
                };
                SendEvent(Consts.E_BuyFootBall, e);
                break;
            case ItemState.Buy:
                //TODO发消息装备
                Debug.Log("装备");
                FootBallArgs ee = new FootBallArgs
                {
                    index = selectIndex,
                    coin = 0,
                    state = ItemState.Equiep
                };
                SendEvent(Consts.E_EquipeFootBall, ee);
                break;
            case ItemState.Equiep:
                break;
        }
    }
    
}