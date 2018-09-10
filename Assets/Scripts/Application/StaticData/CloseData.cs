using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseData
{
    public Texture texture;
    public int coin;
    public Sprite sprite;
    public int skillAdd;

    public CloseData(int _coin,Texture _texture,Sprite _sprite,int _skillAdd)
    {
        coin = _coin;
        texture = _texture;
        sprite = _sprite;
        skillAdd = _skillAdd;
    }
}
