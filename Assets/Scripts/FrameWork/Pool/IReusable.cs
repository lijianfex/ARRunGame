using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 可重复使用的物体的行为接口
/// </summary>
public interface  IReusable
{
    //生成时调用
    void OnSpawn();
    //回收时调用
    void OnUnSpawn();
	
}
