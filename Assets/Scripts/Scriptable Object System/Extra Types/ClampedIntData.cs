using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

[CreateAssetMenu(menuName = "ARG/Scriptable Objects/Clamped Int")]
public class ClampedIntData : IntData
{
    [VerticalGroup("Value")]
    [ValidateInput("@minValue < maxValue || (minValue == 0 && maxValue == 0)")]
    [OdinSerialize]
    int minValue;

    [VerticalGroup("Value")]
    [ValidateInput("@maxValue > minValue|| (minValue == 0 && maxValue == 0)")]
    [OdinSerialize]
    int maxValue;

    public override int data 
    { 
        get => Mathf.Clamp(_data, minValue, maxValue);
        set
        {
            int val = Mathf.Clamp(value, minValue, maxValue);
            if(val != _data)
            {
                _data = val;
                NotifyDataChange();
            }
        }
    }
}
