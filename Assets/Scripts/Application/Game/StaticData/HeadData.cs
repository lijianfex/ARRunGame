using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadData {

    public int coin;
    public Sprite sprite;
    public int skillAdd;
    public string name;

    public HeadData(int _coin, Sprite _sprite, int _skillAdd,string _name)
    {
        coin = _coin;       
        sprite = _sprite;
        skillAdd = _skillAdd;
        name = _name;
    }
}
