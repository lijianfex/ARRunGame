﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 球门检测
/// </summary>
public class BallDoorTrigger : MonoBehaviour {

	

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag==Tag.ball)
        {
            other.gameObject.transform.parent.parent.SendMessage("HitBallDoor", SendMessageOptions.RequireReceiver);//---->PlayerMove
            gameObject.transform.parent.parent.SendMessage("ShotGoal", (int)other.transform.position.x);//--->ShotGoal
        }
    }
}
