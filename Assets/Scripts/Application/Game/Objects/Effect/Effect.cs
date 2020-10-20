using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 特效
/// </summary>
public class Effect : ReusableObject
{
    public float LifeTime = 1f;

    public override void OnSpawn()
    {
        StartCoroutine(DestroyCoroutine());
    }

    public override void OnUnSpawn()
    {
        StopAllCoroutines();
    }

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(LifeTime);
        //回收
        Game.Instance.Pool.UnSpawn(gameObject);

    }
}
