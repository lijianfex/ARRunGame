using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 道路物体生成管理器
/// </summary>
public class PatternManager : MonoSingleton<PatternManager> {

    public List<Pattern> Patterns = new List<Pattern>();
	
	void Start () {
		
	}
	
	
	void Update () {
		
	}
}

//一个游戏物体
[Serializable]
public class PatterItem
{
    public string perfabName;
    public Vector3 pos;
}

//一套物体方案
[Serializable]
public class Pattern
{
    public List<PatterItem> PatterItems = new List<PatterItem>();
}