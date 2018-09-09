using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballData
{
    public Material material;//足球材质
    public int coin;   //价格
   

    public FootballData(int _coin,Material _material)
    {
        coin = _coin;
        material = _material;
    }
}
