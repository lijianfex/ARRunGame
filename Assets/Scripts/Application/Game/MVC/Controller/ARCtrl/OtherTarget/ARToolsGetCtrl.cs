using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AR 获取道具
/// </summary>
public class ARToolsGetCtrl : Controller
{
    public override void Execute(object data = null)
    {
        BuyToolsArgs e = data as BuyToolsArgs;
        GameModel gm = GetModel<GameModel>();
        ARSurfaceUI surfaceUI = GetView<ARSurfaceUI>();
        ARObjectUI objectUI = GetView<ARObjectUI>();
        if (gm.GetMoney(e.CoinCount))
        {
            switch (e.itemType)
            {
                case ItemType.ItemInvincible:
                    gm.Invincible += 1;
                    objectUI.TipMessage("获得道具<color=b>无敌口哨</color>，金币 <color=b>+300</color>！" + "\n\n"
                + "返回道具页<color=red>出售</color>"+ "\n" + "返回进行游戏<color=red>使用无敌口哨</color>!");
                    objectUI.UpdateUI();
                    break;
                case ItemType.ItemMultiply:                    
                    gm.Multiply +=1;
                    surfaceUI.TipMessage("获得道具<color=b>金币加倍</color>，金币 <color=b>+200</color>！" + "\n\n"
                + "返回道具页<color=red>出售</color>" + "\n" + "返回进行游戏<color=red>使用金币加倍</color>!");
                    surfaceUI.UpdateUI();
                    break;
                case ItemType.ItemMagnet:                    
                    gm.Magnet +=1;
                    surfaceUI.TipMessage("获得道具<color=b>吸币磁铁</color>，金币 <color=b>+100</color>！" + "\n\n"
                + "返回道具页<color=red>出售</color>" + "\n" + "返回进行游戏<color=red>使用吸币磁铁</color>!");
                    surfaceUI.UpdateUI();
                    break;
            }
        }
        
    }
}
