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
    [Header("----足球资源-----")]
    public List<Material> FootballMaterialList;
    public List<Sprite> FootBallSprites;

    //---衣服相关------
    Dictionary<int, CloseData> m_CloseDataDis = new Dictionary<int, CloseData>();
    [Header("----衣服资源-----")]
    public List<Texture> CloseTextureList;
    public List<Sprite> CloseSprites;

    //---头像相关------
    Dictionary<int, HeadData> m_HeadDataDis = new Dictionary<int, HeadData>();
    [Header("----头像资源-----")]   
    public List<Sprite> HeadSprites;

    //---鞋子相关------
    Dictionary<int, ShoseData> m_ShoseDataDis = new Dictionary<int, ShoseData>();
    [Header("----鞋子资源-----")]
    public List<Sprite> ShoseSprites;

    protected override void Awake()
    {
        base.Awake();
        InitFootballData();
        InitCloseData();
        InitHeadData();
        InitShoseData();
    }

    //初始化足球信息
    void InitFootballData()
    {
        m_FootballDataDis.Add(0, new FootballData(0, FootballMaterialList[0], FootBallSprites[0],300));
        m_FootballDataDis.Add(1, new FootballData(200, FootballMaterialList[1], FootBallSprites[1], 500));
        m_FootballDataDis.Add(2, new FootballData(400, FootballMaterialList[2], FootBallSprites[2], 800));
    }

    //获取足球信息
    public FootballData GetFootballData(int index)
    {
        return m_FootballDataDis[index];
    }


    //初始化衣服
    void InitCloseData()
    {
        m_CloseDataDis.Add(0, new CloseData(0, CloseTextureList[0], CloseSprites[0], 200));
        m_CloseDataDis.Add(1, new CloseData(100, CloseTextureList[1], CloseSprites[1], 450));
        m_CloseDataDis.Add(2, new CloseData(300, CloseTextureList[2], CloseSprites[2], 700));
    }

    //获取衣服信息
    public CloseData GetCloseData(int index)
    {
        return m_CloseDataDis[index];
    }

    //初始化头像
    void InitHeadData()
    {
        m_HeadDataDis.Add(0, new HeadData(0, HeadSprites[0], 3,"MOMO"));
        m_HeadDataDis.Add(1, new HeadData(300, HeadSprites[1], 5,"AIAI"));
        m_HeadDataDis.Add(2, new HeadData(500, HeadSprites[2], 7,"QIQI"));
    }

    //获取头像信息
    public HeadData GetHeadData(int index)
    {
        return m_HeadDataDis[index];
    }

    //初始化鞋子
    void InitShoseData()
    {
        m_ShoseDataDis.Add(0, new ShoseData(0, ShoseSprites[0], 100));
        m_ShoseDataDis.Add(1, new ShoseData(40, ShoseSprites[1], 300));
        m_ShoseDataDis.Add(2, new ShoseData(50, ShoseSprites[2], 500));
    }

    //获取鞋子信息
    public ShoseData GetShoseData(int index)
    {
        return m_ShoseDataDis[index];
    }


}
