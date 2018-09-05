using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetEffect : Effect {

    public override void OnSpawn()
    {
        base.OnSpawn();
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one * 2f;
    }

    public override void OnUnSpawn()
    {
        base.OnUnSpawn();
    }
}
