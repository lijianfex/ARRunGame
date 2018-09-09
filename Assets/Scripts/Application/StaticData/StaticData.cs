using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 静态全局数据
/// </summary>
public class StaticData : MonoSingleton<StaticData>
{
    //---足球相关----
    Dictionary<int, FootballData> m_FootballDataDis = new Dictionary<int, FootballData>();
    public List<Material> FootballMaterialList;
    public List<Sprite> FootBallSprites;

    //初始化足球信息
    void InitFootballData()
    {
        m_FootballDataDis.Add(0, new FootballData(0, FootballMaterialList[0], FootBallSprites[0]));
        m_FootballDataDis.Add(1, new FootballData(200, FootballMaterialList[1], FootBallSprites[1]));
        m_FootballDataDis.Add(2, new FootballData(400, FootballMaterialList[2], FootBallSprites[2]));
    }

    //获取足球信息
    public FootballData GetFootballData(int index)
    {
        return m_FootballDataDis[index];
    }

    protected override void Awake()
    {
        base.Awake();
        InitFootballData();
    }

}
