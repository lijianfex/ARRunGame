using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可重复使用游戏对象基类
/// </summary>
public abstract class ReusableObject : MonoBehaviour, IReusable
{
    public abstract void OnSpawn();

    public abstract void OnUnSpawn();
    
}
