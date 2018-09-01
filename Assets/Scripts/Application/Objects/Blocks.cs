﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : ReusableObject {

	Transform effectParent;

    private void Awake()
    {
        effectParent = GameObject.Find("EffectParent").transform;
    }

    public override void OnSpawn()
    {

    }

    public override void OnUnSpawn()
    {

    }

    public void HitPlayer(Vector3 Hitpos)
    {
        //1.生成特效
        GameObject go = Game.Instance.Pool.Spawn("FX_ZhuangJi", effectParent);
        go.transform.position = Hitpos;

        //2.声音
        Game.Instance.Sound.PlayEffect("Se_UI_Hit");

        //3.回收
        //Game.Instance.Pool.UnSpawn(gameObject);
        Destroy(gameObject);

    }
}
