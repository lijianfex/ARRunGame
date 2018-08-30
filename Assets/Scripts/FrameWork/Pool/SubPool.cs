using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 子对象池
/// </summary>
public class SubPool
{
    //物体集合
    List<GameObject> m_objects = new List<GameObject>();

    //预设
    GameObject m_prefab;

    //对象池名
    public string Name {get { return m_prefab.name; } }

    Transform m_parent;

    public SubPool(Transform parent,GameObject go)
    {
        m_prefab = go;
        m_parent = parent;
    }

    //取游戏对象
    public GameObject Spawn()
    {
        GameObject go = null;
        foreach(var obj in m_objects)
        {
            if(obj.activeSelf==false)
            {
                go = obj;
            }
        }

        if(go==null)
        {
            go = GameObject.Instantiate<GameObject>(m_prefab);
            go.transform.parent = m_parent;
            m_objects.Add(go);
        }

        go.SetActive(true);
        go.SendMessage("OnSpawn",SendMessageOptions.DontRequireReceiver);
        return go;
   
    }

    //回收游戏对象
    public void UnSpawn(GameObject go)
    {
        if(Contains(go))
        {
            go.SendMessage("OnUnSpawn", SendMessageOptions.DontRequireReceiver);
            go.SetActive(false);
        }
    }

    //回收所有游戏对象
    public void UnSpawnAll()
    {
        foreach(var obj in m_objects)
        {
            if(obj.activeSelf)
            {
                UnSpawn(obj);
            }
        }
    }

    //判断池子中是否包含该游戏对象
    public bool Contains(GameObject go)
    {
        return m_objects.Contains(go);
    }
}

