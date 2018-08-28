using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// View基类
/// </summary>
public abstract class View : MonoBehaviour
{
    //名字标识
    public abstract string Name { get; }

    //该view所处理事件列表
    public List<string> attentionList = new List<string>();

    //处理事件--通过事件名判断处理那个事件
    public abstract void HandleEvent(string name, object data = null);
	
}
