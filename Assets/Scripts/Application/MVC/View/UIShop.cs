using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 商场界面
/// </summary>
public class UIShop : View
{
    
    [Header("------资源图-----")]
    public Sprite SpUnBuy;
    public Sprite SpBuy;
    public Sprite SpEquipe;
    public Sprite spBuyBtn;
    public Sprite spEquiepeBtn;

    //-----金币----
    public Text Coin_txt;//金币

    //---------------------足球------------------------
    [Header("------足球-----")]
    public Image FootballEquipImg;//足球已装备图

    public MeshRenderer FootballMesh;//足球

    public List<Toggle> FootballTogList;

    public List<Image> FootballStateList;

    public List<Text> FootballCoinTextList;

    public Button FootBallBuyBtn;

    public Slider ShotQulitySlider;
    public Text ShotQulityText;

    [Header("------衣服-----")]
    public Image ColseEquipImg;//衣服已装备

    public SkinnedMeshRenderer CloseMesh;

    public List<Toggle> CloseTogList;

    public List<Image> CloseStateList;

    public List<Text> CloseCoinTextList;

    public Button CloseBuyBtn;

    public Slider ShotSlider;
    public Text ShotText;

    
    


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
        UpdateCloseUI();
    }

    //-----------------------足球---------------------
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
                gm.ShotQulity=Game.Instance.Data.GetFootballData(info.Index).skillAdd;
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

        UpdateShotQulityUI(gm.ShotQulity);
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
                ShopArgs e = new ShopArgs
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
                ShopArgs ee = new ShopArgs
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

    //更新足球技能加成
    private void UpdateShotQulityUI(int skill)
    {
        ShotQulitySlider.value = (float)skill;
        ShotQulityText.text = skill.ToString();
    }
    

    //---------------------衣服---------------------
    public void UpdateCloseUI()
    {
        foreach (CloseInfo info in gm.CloseInfoList)
        {
            //更新衣服已装备图,与选中Toggle
            if (info.State == ItemState.Equiep)
            {
                ColseEquipImg.overrideSprite = Game.Instance.Data.GetCloseData(info.Index).sprite;
                CloseTogList[info.Index].isOn = true;
                CloseBuyBtnUpdate(info.Index);//购买按钮
                CloseMesh.material.mainTexture = Game.Instance.Data.GetCloseData(info.Index).texture;
                gm.Shot = Game.Instance.Data.GetCloseData(info.Index).skillAdd;
            }
            switch (info.State)
            {
                case ItemState.UnBuy:
                    CloseStateList[info.Index].overrideSprite = SpUnBuy;
                    break;
                case ItemState.Buy:
                    CloseStateList[info.Index].overrideSprite = SpBuy;
                    break;
                case ItemState.Equiep:
                    CloseStateList[info.Index].overrideSprite = SpEquipe;
                    break;
            }
            CloseCoinTextList[info.Index].text = Game.Instance.Data.GetCloseData(info.Index).coin.ToString();
        }

        UpdateShotUI(gm.Shot);
    }

    public void OnClose1Click()
    {
        CloseBuyBtnUpdate(0);
        selectIndex = 0;
    }
    public void OnClose2Click()
    {
        CloseBuyBtnUpdate(1);
        selectIndex = 1;
    }
    public void OnClose3Click()
    {
        CloseBuyBtnUpdate(2);
        selectIndex = 2;
    }

    private void CloseBuyBtnUpdate(int index)
    {
        switch (gm.CloseInfoList[index].State)
        {
            case ItemState.UnBuy:
                CloseBuyBtn.gameObject.SetActive(true);
                CloseBuyBtn.GetComponent<Image>().overrideSprite = spBuyBtn;
                break;
            case ItemState.Buy:
                CloseBuyBtn.gameObject.SetActive(true);
                CloseBuyBtn.GetComponent<Image>().overrideSprite = spEquiepeBtn;
                break;
            case ItemState.Equiep:
                CloseBuyBtn.gameObject.SetActive(false);
                break;
        }
    }

    public void OnCloseBuyBtnClick()
    {
        switch (gm.CloseInfoList[selectIndex].State)
        {
            case ItemState.UnBuy:
                //TODO发消息购买
                Debug.Log("购买");
                ShopArgs e = new ShopArgs
                {
                    index = selectIndex,
                    coin = Game.Instance.Data.GetCloseData(selectIndex).coin,
                    state = ItemState.Buy
                };
                SendEvent(Consts.E_CloseBuy, e);
                break;
            case ItemState.Buy:
                //TODO发消息装备
                Debug.Log("装备");
                ShopArgs ee = new ShopArgs
                {
                    index = selectIndex,
                    coin = 0,
                    state = ItemState.Equiep
                };
                SendEvent(Consts.E_CloseEquipe, ee);
                break;
            case ItemState.Equiep:
                break;
        }
    }

    private void UpdateShotUI(int skill)
    {
        ShotSlider.value = (float)skill;
        ShotText.text = skill.ToString();
    }
    

}