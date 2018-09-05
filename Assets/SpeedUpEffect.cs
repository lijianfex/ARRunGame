using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpEffect : Effect {

    public override void OnSpawn()
    {
        base.OnSpawn();
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one;
    }

    public override void OnUnSpawn()
    {
        base.OnUnSpawn();        
    }
}
