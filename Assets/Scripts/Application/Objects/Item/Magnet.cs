using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Item {

    public override void OnSpawn()
    {
       
    }

    public override void OnUnSpawn()
    {
       
    }

    public override void HitPlayer(Vector3 pos)
    {
        //2.播放音效
        Game.Instance.Sound.PlayEffect("Se_UI_Stars");

        //3.回收
        //Game.Instance.Pool.UnSpawn(gameObject);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tag.player)
        {
            HitPlayer(other.transform.position);
            other.gameObject.SendMessage("HitMagnet", SendMessageOptions.RequireReceiver);
        }
    }
}
