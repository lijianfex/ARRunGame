using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEffect : Effect {

    public override void OnSpawn()
    {
        transform.localPosition = new Vector3(0, 13.0f, 7.5f);
        transform.localScale = Vector3.one;
        base.OnSpawn();
    }
    
}
