using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 奖励品基类
/// </summary>
public class Item : ReusableObject
{
    public float Speed=60;

    public override void OnSpawn()
    {
        
    }

    public override void OnUnSpawn()
    {
        transform.localEulerAngles = Vector3.zero;
    }

    protected virtual void Update()
    {
        transform.Rotate(0, Speed * Time.deltaTime, 0);
    }

    public virtual void HitPlayer(Vector3 pos)
    {

    }
}
