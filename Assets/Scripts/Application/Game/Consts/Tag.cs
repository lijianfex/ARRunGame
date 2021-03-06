﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tag
{
    public const string road = "Road";//跑道
    public const string player = "Player";//玩家
    public const string smallFence = "SmallFence";//小栅栏
    public const string bigFence = "BigFence";//大栅栏

    public const string block = "Block";//集装箱
    public const string smallBlock = "SmallBlock";//集装箱前部

    public const string carBeforeTrigger = "BeforeTrigger"; //车前部的触发器

    public const string magnetCollider = "MagnetCollider"; //吸铁石

    //射门
    public const string beforeGoalTrigger = "BeforeGoalTrigger";//球门前的触发器
    public const string ball = "Ball";//球

    public const string goalKeeper = "GoalKeeper";//守门员

    public const string ballDoor = "BallDoor";//球门

    //ARUI
    public const string ARImageUI = "ARImageUI"; //图片识别UI
    public const string ARSurfaceUI = "ARSurfaceUI";//表面识别UI
    public const string ARObjectUI = "ARObjectUI";//模型识别UI


    //AR Player
    public const string AR_Player = "AR_Player"; //AR小熊角色



}
