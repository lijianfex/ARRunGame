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
    public GameObject net;

    public override void OnSpawn()
    {
        
    }

    public override void OnUnSpawn()
    {
        GoalKeeperAnim.Play("standard");
        DoorAnim.Play("QiuMen_St");
        net.SetActive(true);
        GoalKeeperAnim.gameObject.transform.parent.parent.gameObject.SetActive(true);
        GoalKeeperAnim.gameObject.transform.parent.parent.localPosition = Vector3.zero;//将守门员归位
        m_isFly = false;
        StopAllCoroutines();
    }

    //进球了,子物体发消息
    public void ShotGoal(int i)
    {
        switch (i)
        {
            case -2:
                GoalKeeperAnim.Play("left_flutter");//左边守门动画
                break;
            case 0:
                GoalKeeperAnim.Play("flutter");//中间守门动画
                break;
            case 2:
                GoalKeeperAnim.Play("right_flutter");//右边守门动画
                break;
            default:
                break;
        }
        StartCoroutine(HideGoalKeeper());
    }

    IEnumerator HideGoalKeeper()
    {
        yield return new WaitForSeconds(1f);
        GoalKeeperAnim.gameObject.transform.parent.parent.gameObject.SetActive(false);
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
            GoalKeeperAnim.gameObject.transform.parent.parent.position += new Vector3(0, speed, speed) * Time.deltaTime;
        }
    }

    //撞到球门
    public void HitDoor(RunWay runWay)
    {
        //door动画
        switch (runWay)
        {
            case RunWay.Left:
                DoorAnim.Play("QiuMen_RR");
                break;
            case RunWay.Middle:
                DoorAnim.Play("QiuMen_St");
                break;
            case RunWay.Right:
                DoorAnim.Play("QiuMen_LR");
                break;
        }
        //球网消失
        net.SetActive(false);
    }
}