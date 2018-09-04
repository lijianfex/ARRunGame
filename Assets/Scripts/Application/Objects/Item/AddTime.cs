using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 加时道具
/// </summary>
public class AddTime : Item
{
    public override void OnSpawn()
    {
        base.OnSpawn();
    }

    public override void OnUnSpawn()
    {
        base.OnUnSpawn();
    }

    public override void HitPlayer(Vector3 pos)
    {
        //声音
        Game.Instance.Sound.PlayEffect("Se_UI_Time");

        //Game.Instance.Pool.UnSpawn(gameObject);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag==Tag.player)
        {
            HitPlayer(other.transform.position);
            //other.SendMessage("HitAddTime", SendMessageOptions.RequireReceiver);
            other.gameObject.SendMessage("HitItem", ItemType.ItemAddTime);

        }
    }

}
