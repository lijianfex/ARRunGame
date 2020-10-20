using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadInfo {

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

    public HeadInfo(int _index, ItemState _state = ItemState.UnBuy)
    {
        index = _index;
        state = _state;
    }
}
