﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager> {

    //资源目录
    public string ResourceObjectPath = "";

    //子池子字典
    Dictionary<string, SubPool> m_pools = new Dictionary<string, SubPool>();
	
    //取出游戏对象
    public GameObject Spawn(string name,Transform trans)
    {
        SubPool pool = null;
        if(!m_pools.ContainsKey(name))
        {
            RegisterNew(name, trans);
        }
        pool = m_pools[name];
        return pool.Spawn();
    }

    //回收游戏对象
    public void UnSpawn(GameObject go)
    {
        SubPool pool = null;
        foreach(var p in m_pools.Values)
        {
            if(p.Contains(go))
            {
                pool = p;
                break;
            }
        }
        pool.UnSpawn(go);
    }

    //回收所有游戏对象
    public void UnSpawnAll()
    {
        if(m_pools.Values==null)
        {
            return;
        }
        foreach(var p in m_pools.Values)
        {
            p.UnSpawnAll();
        }
    }

    public void ClearDis()
    {
        m_pools.Clear();
    }

    //新建池子
    void RegisterNew(string name,Transform trans)
    {
        string path = ResourceObjectPath + "/" + name;
        GameObject go = Resources.Load<GameObject>(path);
        SubPool pool = new SubPool(trans, go);
        m_pools.Add(pool.Name, pool);
    }
}
