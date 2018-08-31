﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    private Animation anim;
    Action PlayAnim;

    private void Awake()
    {
        anim = GetComponent<Animation>();
        PlayAnim = PlayRun;
    }


    void Update()
    {
        if (PlayAnim != null)
        {
            PlayAnim();
        }
    }

    void PlayRun()
    {
        anim.Play("run");

    }

    void PlayLeft()
    {
        anim.Play("left_jump");
        if (anim["left_jump"].normalizedTime > 0.95)
        {
            PlayAnim = PlayRun;
        }
    }

    void PlayRight()
    {
        anim.Play("right_jump");
        if (anim["right_jump"].normalizedTime > 0.95)
        {
            PlayAnim = PlayRun;
        }
    }

    void PlayRoll()
    {
        anim.Play("roll");
        if (anim["roll"].normalizedTime > 0.95)
        {
            PlayAnim = PlayRun;
        }
    }
    void PlayJump()
    {
        anim.Play("jump");
        if (anim["jump"].normalizedTime > 0.95)
        {
            PlayAnim = PlayRun;
        }

    }

    public void AnimManager(InputDirection dir)
    {
        switch (dir)
        {
            case InputDirection.NULL:
                break;
            case InputDirection.Right:
                PlayAnim = PlayRight;
                break;
            case InputDirection.Left:
                PlayAnim = PlayLeft;
                break;
            case InputDirection.Up:
                PlayAnim = PlayJump;
                break;
            case InputDirection.Down:
                PlayAnim = PlayRoll;
                break;
        }
    }
}