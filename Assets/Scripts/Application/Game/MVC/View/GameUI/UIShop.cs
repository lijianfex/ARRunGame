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

    //-----提示----
    public Text Message_txt;//提示


    [Header("------足球-----")]
    public Image FootballEquipImg;//足球已装备图
    public MeshRenderer FootballMesh;//足球
    public List<Toggle> FootballTogList;//三个足球
    public List<Image> FootballStateList;//三个足球的状态图
    public List<Text> FootballCoinTextList;//三个足球的
    public Button FootBallBuyBtn;
    public Slider ShotQulitySlider;
    public Text ShotQulityText;

    [Header("------衣服-----")]
    public Image ColseEquipImg;//衣服已装备图
    public SkinnedMeshRenderer CloseMesh;
    public List<Toggle> CloseTogList;
    public List<Image> CloseStateList;
    public List<Text> CloseCoinTextList;
    public Button CloseBuyBtn;
    public Slider ShotSlider;
    public Text ShotText;

    [Header("-----头像------")]
    public Image HeadEquipeImg;
    public Text NameTxt;
    public Text LeveTxt;
    public List<Toggle> HeadTogList;
    public List<Image> HeadStateList;
    public List<Text> HeadCoinTextList;
    public Button HeadBuyBtn;
    public List<Slider> SkillTimeSlider;
    public List<Text> SkillTimeText;

    [Header("------鞋子-----")]
    public Image ShoseEquipImg;//衣服已装备   
    public List<Toggle> ShoseTogList;
    public List<Image> ShoseStateList;
    public List<Text> ShoseCoinTextList;
    public Button ShoseBuyBtn;
    public Slider SpeedAddSlider;
    public Text SpeedAddText;

    GameModel gm;

    int selectIndex;//当前点击的是具体第几个头像，衣服，足球，鞋子


    private void Awake()
    {
        gm = GetModel<GameModel>();
        UpdateUI(); //更新UI
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

    //全局更新UI,可被相关Controller调用
    public void UpdateUI()
    {
        Coin_txt.text = gm.Coin.ToString();
        UpdateFootballUI();
        UpdateCloseUI();
        UpdateHeadUI();
        UpdateShoseUI();
    }

    //点击shop上方的头像，球服，足球，球鞋【toggle】
    public void OnSelectClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        UpdateUI();
    }

    //提示消息
    public void TipMessage(string msg)
    {
        Message_txt.gameObject.SetActive(true);
        Message_txt.text = msg;
        StartCoroutine(MessageCor());
    }
    IEnumerator MessageCor()
    {
        yield return new WaitForSeconds(2f);
        Message_txt.gameObject.SetActive(false);
    }


    #region 足球
    //-----------------------足球---------------------

    //足球UI更新
    private void UpdateFootballUI()
    {

        foreach (FootballInfo info in gm.FootballInfoList)
        {
            //更新足球已装备图,与选中Toggle
            if (info.State == ItemState.Equiep)
            {
                FootballEquipImg.overrideSprite = Game.Instance.Data.GetFootballData(info.Index).sprite;
                FootballTogList[info.Index].isOn = true;
                FootBallBuyBtnUpdate(info.Index);//购买按钮
                FootballMesh.material = Game.Instance.Data.GetFootballData(info.Index).material;
                gm.ShotQulity = Game.Instance.Data.GetFootballData(info.Index).skillAdd;
            }
            else
            {
                FootballTogList[info.Index].isOn = false;
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
    //更新足球技能UI
    private void UpdateShotQulityUI(int skill)
    {
        ShotQulitySlider.value = (float)skill;
        ShotQulityText.text = skill.ToString();
    }

    //足球【Toggle】点击,以显示是购买按钮，还是装备按钮
    public void OnFootball1Click()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        FootBallBuyBtnUpdate(0);
        selectIndex = 0;
    }
    public void OnFootball2Click()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        FootBallBuyBtnUpdate(1);
        selectIndex = 1;

    }
    public void OnFootball3Click()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
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

    //足球【购买】或者【装备】点击
    public void OnFootBallBuyBtnClick()
    {
        switch (gm.FootballInfoList[selectIndex].State)
        {
            case ItemState.UnBuy:
                Game.Instance.Sound.PlayEffect("Se_UI_Button");
                ShopArgs e = new ShopArgs
                {
                    index = selectIndex,
                    coin = Game.Instance.Data.GetFootballData(selectIndex).coin,
                    state = ItemState.Buy
                };
                SendEvent(Consts.E_BuyFootBall, e);
                break;
            case ItemState.Buy:
                Game.Instance.Sound.PlayEffect("Se_UI_Dress");
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


    #endregion

    #region 衣服
    //---------------------衣服---------------------
    //衣服UI更新
    private void UpdateCloseUI()
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
            else
            {
                CloseTogList[info.Index].isOn = false;
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
    //更新衣服技能UI
    private void UpdateShotUI(int skill)
    {
        ShotSlider.value = (float)skill;
        ShotText.text = skill.ToString();
    }

    //衣服【Toggle】点击,以显示是购买按钮，还是装备按钮
    public void OnClose1Click()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        CloseBuyBtnUpdate(0);
        selectIndex = 0;
    }
    public void OnClose2Click()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        CloseBuyBtnUpdate(1);
        selectIndex = 1;
    }
    public void OnClose3Click()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
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

    //衣服【购买】或者【装备】点击
    public void OnCloseBuyBtnClick()
    {
        switch (gm.CloseInfoList[selectIndex].State)
        {
            case ItemState.UnBuy:
                Game.Instance.Sound.PlayEffect("Se_UI_Button");
                ShopArgs e = new ShopArgs
                {
                    index = selectIndex,
                    coin = Game.Instance.Data.GetCloseData(selectIndex).coin,
                    state = ItemState.Buy
                };
                SendEvent(Consts.E_CloseBuy, e);
                break;
            case ItemState.Buy:
                Game.Instance.Sound.PlayEffect("Se_UI_Dress");
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


    #endregion

    #region 头像
    //头像UI更新
    private void UpdateHeadUI()
    {
        foreach (HeadInfo info in gm.HeadInfoList)
        {
            //更新衣服已装备图,与选中Toggle
            if (info.State == ItemState.Equiep)
            {
                HeadEquipeImg.overrideSprite = Game.Instance.Data.GetHeadData(info.Index).sprite;
                HeadTogList[info.Index].isOn = true;
                HeadBuyBtnUpdate(info.Index);//购买按钮                
                gm.SkillTime = Game.Instance.Data.GetHeadData(info.Index).skillAdd;
                NameTxt.text = Game.Instance.Data.GetHeadData(info.Index).name;
                LeveTxt.text = gm.Level.ToString();
            }
            else
            {
                HeadTogList[info.Index].isOn = false;

            }
            switch (info.State)
            {
                case ItemState.UnBuy:
                    HeadStateList[info.Index].overrideSprite = SpUnBuy;
                    break;
                case ItemState.Buy:
                    HeadStateList[info.Index].overrideSprite = SpBuy;
                    break;
                case ItemState.Equiep:
                    HeadStateList[info.Index].overrideSprite = SpEquipe;
                    break;
            }
            HeadCoinTextList[info.Index].text = Game.Instance.Data.GetHeadData(info.Index).coin.ToString();
        }

        UpdateSkillTimeUI(gm.SkillTime);
    }
    //更新头像技能UI
    private void UpdateSkillTimeUI(int skill)
    {
        for (int i = 0; i < 3; i++)
        {
            SkillTimeSlider[i].value = (float)skill;
            SkillTimeText[i].text = skill.ToString();
        }

    }

    //头像【Toggle】点击,以显示是购买按钮，还是装备按钮
    public void OnHead1Click()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        HeadBuyBtnUpdate(0);
        selectIndex = 0;
    }
    public void OnHead2Click()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        HeadBuyBtnUpdate(1);
        selectIndex = 1;
    }
    public void OnHead3Click()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        HeadBuyBtnUpdate(2);
        selectIndex = 2;
    }
    private void HeadBuyBtnUpdate(int index)
    {
        switch (gm.HeadInfoList[index].State)
        {
            case ItemState.UnBuy:
                HeadBuyBtn.gameObject.SetActive(true);
                HeadBuyBtn.GetComponent<Image>().overrideSprite = spBuyBtn;
                break;
            case ItemState.Buy:
                HeadBuyBtn.gameObject.SetActive(true);
                HeadBuyBtn.GetComponent<Image>().overrideSprite = spEquiepeBtn;
                break;
            case ItemState.Equiep:
                HeadBuyBtn.gameObject.SetActive(false);
                break;
        }
    }

    //头像【购买】或者【装备】点击
    public void OnHeadBuyBtnClick()
    {
        switch (gm.HeadInfoList[selectIndex].State)
        {
            case ItemState.UnBuy:
                Game.Instance.Sound.PlayEffect("Se_UI_Button");
                ShopArgs e = new ShopArgs
                {
                    index = selectIndex,
                    coin = Game.Instance.Data.GetHeadData(selectIndex).coin,
                    state = ItemState.Buy
                };
                SendEvent(Consts.E_HeadBuy, e);
                break;
            case ItemState.Buy:
                Game.Instance.Sound.PlayEffect("Se_UI_Button");
                ShopArgs ee = new ShopArgs
                {
                    index = selectIndex,
                    coin = 0,
                    state = ItemState.Equiep
                };
                SendEvent(Consts.E_HeadEquipe, ee);
                break;
            case ItemState.Equiep:
                break;
        }
    }


    #endregion

    #region 鞋子
    //鞋子UI更新
    private void UpdateShoseUI()
    {
        foreach (ShoseInfo info in gm.ShoseInfoList)
        {
            //更新衣服已装备图,与选中Toggle
            if (info.State == ItemState.Equiep)
            {
                ShoseEquipImg.overrideSprite = Game.Instance.Data.GetShoseData(info.Index).sprite;
                ShoseTogList[info.Index].isOn = true;
                ShoseBuyBtnUpdate(info.Index);//购买按钮               
                gm.SpeedAdd = Game.Instance.Data.GetShoseData(info.Index).skillAdd;
            }
            else
            {
                ShoseTogList[info.Index].isOn = false;
            }
            switch (info.State)
            {
                case ItemState.UnBuy:
                    ShoseStateList[info.Index].overrideSprite = SpUnBuy;
                    break;
                case ItemState.Buy:
                    ShoseStateList[info.Index].overrideSprite = SpBuy;
                    break;
                case ItemState.Equiep:
                    ShoseStateList[info.Index].overrideSprite = SpEquipe;
                    break;
            }
            ShoseCoinTextList[info.Index].text = Game.Instance.Data.GetShoseData(info.Index).coin.ToString();
        }

        UpdateShoseUI(gm.SpeedAdd);
    }
    //更新鞋子技能UI
    private void UpdateShoseUI(int skill)
    {
        SpeedAddSlider.value = (float)skill;
        SpeedAddText.text = skill.ToString();
    }

    //鞋子【Toggle】点击,以显示是购买按钮，还是装备按钮
    public void OnShose1Click()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        ShoseBuyBtnUpdate(0);
        selectIndex = 0;
    }
    public void OnShose2Click()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        ShoseBuyBtnUpdate(1);
        selectIndex = 1;
    }
    public void OnShose3Click()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        ShoseBuyBtnUpdate(2);
        selectIndex = 2;
    }
    private void ShoseBuyBtnUpdate(int index)
    {
        switch (gm.ShoseInfoList[index].State)
        {
            case ItemState.UnBuy:
                ShoseBuyBtn.gameObject.SetActive(true);
                ShoseBuyBtn.GetComponent<Image>().overrideSprite = spBuyBtn;
                break;
            case ItemState.Buy:
                ShoseBuyBtn.gameObject.SetActive(true);
                ShoseBuyBtn.GetComponent<Image>().overrideSprite = spEquiepeBtn;
                break;
            case ItemState.Equiep:
                ShoseBuyBtn.gameObject.SetActive(false);
                break;
        }
    }

    //鞋子【购买】或者【装备】点击
    public void OnShoseBuyBtnClick()
    {
        switch (gm.ShoseInfoList[selectIndex].State)
        {
            case ItemState.UnBuy:
                Game.Instance.Sound.PlayEffect("Se_UI_Button");
                ShopArgs e = new ShopArgs
                {
                    index = selectIndex,
                    coin = Game.Instance.Data.GetShoseData(selectIndex).coin,
                    state = ItemState.Buy
                };
                SendEvent(Consts.E_ShoseBuy, e);
                break;
            case ItemState.Buy:
                Game.Instance.Sound.PlayEffect("Se_UI_Button");
                ShopArgs ee = new ShopArgs
                {
                    index = selectIndex,
                    coin = 0,
                    state = ItemState.Equiep
                };
                SendEvent(Consts.E_ShoseEquipe, ee);
                break;
            case ItemState.Equiep:
                break;
        }
    }

    
    #endregion

    //返回上个场景
    public void OnReturnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");
        if (gm.LastSenceIndex == Levels.Game)
            gm.LastSenceIndex = Levels.MainMenu;
        Game.Instance.Level.LoadLevel(gm.LastSenceIndex);
    }

    //开始游戏
    public void OnPlayClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        Game.Instance.Level.LoadLevel(Levels.BuyTools);
    }

    //返回主页
    public void OnMainMenuBtnClick()
    {
        Game.Instance.Sound.PlayEffect("Se_UI_Button");

        Game.Instance.Level.LoadLevel(Levels.MainMenu);
    }

}