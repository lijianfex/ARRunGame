using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///足球信息
/// </summary>
public class FootballInfo
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

    public FootballInfo(int _index,ItemState _state=ItemState.UnBuy)
    {
        index = _index;
        state = _state;
    }
	
}
 