using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 球门
/// </summary>
public class ShootGoal : ReusableObject
{
    public Animation GoalKeeperAnim;
    public Animation DoorAnim;

    public float speed = 20f;
    bool m_isFly = false;

    public override void OnSpawn()
    {
        GoalKeeperAnim.Play("standard");
    }

    public override void OnUnSpawn()
    {
        GoalKeeperAnim.gameObject.SetActive(true);
        GoalKeeperAnim.gameObject.transform.localPosition = Vector3.zero;
        m_isFly = false;
    }

    //进球了,子物体发消息
    public void ShotGoal()
    {
        GoalKeeperAnim.gameObject.SetActive(false);
    }

    //撞飞守门员
    public void HitGoalKeeper()
    {
        //守门员飞走
        m_isFly = true;
        //动画
        GoalKeeperAnim.Play("fly");

       

        //声音
        Game.Instance.Sound.PlayEffect("Se_UI_Hit");
    }

    private void Update()
    {
        if(m_isFly)
        {
            GoalKeeperAnim.gameObject.transform.position += new Vector3(0, speed, speed) * Time.deltaTime;
        }
    }
}
