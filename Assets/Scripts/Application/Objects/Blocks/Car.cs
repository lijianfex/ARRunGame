using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 车
/// </summary>
public class Car : Blocks
{

    public bool canMove = false;
    bool isBlock = false;
    public float moveSpeed = 20f;
    GameModel gm;

    protected override void Awake()
    {
        base.Awake();
        gm = MVC.GetModle<GameModel>();
    }

    public override void OnSpawn()
    {
        base.OnSpawn();
    }

    public override void OnUnSpawn()
    {
        isBlock = false;
        base.OnUnSpawn();
    }

    public override void HitPlayer(Vector3 Hitpos)
    {
        base.HitPlayer(Hitpos);
    }

    //碰到触发区域
    public void HitTrigger()
    {
        isBlock = true;
    }

    private void Update()
    {
        if (isBlock && canMove && gm.IsPlay && !gm.IsPause)
        {
            transform.Translate(-transform.forward * moveSpeed * Time.deltaTime);
        }
    }
}
