using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 跑的熊
/// </summary>
public class Bear : Obstacles
{

    bool isHit = false;
    bool isFly = false;
    public float RunSpeed = 10f;

    Animation anim;

    GameModel gm;

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponentInChildren<Animation>();
        gm = MVC.GetModle<GameModel>();
    }

    public override void OnSpawn()
    {
        base.OnSpawn();
        anim.Play("run");
    }

    public override void OnUnSpawn()
    {

        base.OnUnSpawn();
        anim.transform.localPosition = Vector3.zero;
        isHit = false;
        isFly = false;
    }

    public override void HitPlayer(Vector3 Hitpos)
    {
        //1.生成特效
        GameObject go = Game.Instance.Pool.Spawn("FX_ZhuangJi", effectParent);
        go.transform.position = Hitpos;

        //2.声音
        Game.Instance.Sound.PlayEffect("Se_UI_Hit");
        isHit = false;
        isFly = true;
        anim.Play("fly");
    }

    //开始移动
    public void HitTrigger()
    {
        isHit = true;
    }

    private void Update()
    {
        if (isHit && gm.IsPlay && !gm.IsPause)
        {
            transform.position += new Vector3(-RunSpeed, 0, 0) * Time.deltaTime;
        }
        if (isFly && gm.IsPlay && !gm.IsPause)
        {
            transform.position += new Vector3(0, RunSpeed, RunSpeed) * Time.deltaTime;
        }
    }
}
