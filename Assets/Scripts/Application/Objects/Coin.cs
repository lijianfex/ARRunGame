using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 金币
/// </summary>
public class Coin : Item
{
    Transform effectParent;

    private void Awake()
    {
        effectParent = GameObject.Find("EffectParent").transform;
    }

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
        base.HitPlayer(pos);
        //1.特效
        GameObject go= Game.Instance.Pool.Spawn("FX_JinBi", effectParent);
        go.transform.position = pos;

        //2.播放音效
        Game.Instance.Sound.PlayEffect("Se_UI_JinBi");

        //3.回收
        //Game.Instance.Pool.UnSpawn(gameObject);
        Destroy(gameObject);


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag==Tag.player)
        {
            HitPlayer(other.transform.position);
            other.gameObject.SendMessage("EatCoin", SendMessageOptions.RequireReceiver);
        }
    }

}
