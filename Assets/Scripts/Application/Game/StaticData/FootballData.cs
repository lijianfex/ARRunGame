using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FootballData
{
    public Material material;//足球材质
    public int coin;   //价格
    public Sprite sprite;//图标
    public int skillAdd;//足球技能加成
   

    public FootballData(int _coin,Material _material,Sprite _sprite,int _skillAdd)
    {
        coin = _coin;
        material = _material;
        sprite = _sprite;
        skillAdd = _skillAdd;
    }
}
