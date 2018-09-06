using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 道路
/// </summary>
public class Road : ReusableObject
{
    public override void OnSpawn()
    {
        
    }

    public override void OnUnSpawn()
    {
        //回收Item下的所有子物体
        var ItemChild = transform.Find("Item");//放置物体的Item
        if (ItemChild != null)
        {
            foreach(Transform child in ItemChild)
            {
                if(child!=null)
                {
                    Game.Instance.Pool.UnSpawn(child.gameObject);
                }
            }
        }
    }
}
