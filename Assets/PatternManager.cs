using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PatternManager : MonoBehaviour {

    public List<Pattern> Patterns = new List<Pattern>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
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