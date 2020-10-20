using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 衣服信息
/// </summary>
public class CloseInfo
{

    private int index;

    private ItemState state;

    public int Index
    {
        get
        {
            return index;
        }

    }

    public ItemState State
    {
        get
        {
            return state;
        }

        set
        {
            state = value;
        }
    }

    public CloseInfo(int _index, ItemState _state = ItemState.UnBuy)
    {
        index = _index;
        state = _state;
    }

}
