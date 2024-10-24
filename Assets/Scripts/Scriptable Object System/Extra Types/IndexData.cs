using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ARG/Scriptable Objects/Index")]
public class IndexData : IntData
{
    [VerticalGroup("Value")]
    [OdinSerialize]
    int collectionSize;

    public override int data 
    { 
        get => base.data;
        set 
        {
            if(value != _data)
            {
                if (value < 0 || value >= collectionSize)
                    throw new IndexOutOfRangeException();

                _data = value;
                NotifyDataChange();
            }
        }
    }

    [ButtonGroup()]
    [Button("+")]
    public void Increment()
    {
        int value = _data + 1;
        if (value == collectionSize)
            value = 0;

        data = value;
    }

    [ButtonGroup()]
    [Button("-")]
    public void Decrement()
    {
        int value = _data - 1;
        if (value < 0)
            value = collectionSize - 1;

        data = value;
    }

    public void SetIndexBySign(float a_sign)
    {
        if (Mathf.Sign(a_sign) < 0)
            Increment();
        else
            Decrement();
    }

    [ButtonGroup()]
    [Button("0")]
    public void Reset()
    {
        data = 0;
    }

    [ButtonGroup()]
    [Button("Max")]
    public void SetToMax()
    {
        data = collectionSize - 1;
    }
}
