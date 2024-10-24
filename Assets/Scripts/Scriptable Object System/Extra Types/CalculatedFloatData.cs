using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ARG/Scriptable Objects/Calculated Float")]
public class CalculatedFloatData : FloatData
{
    abstract class Float
    {
        public abstract float GetValue();
    }

    class Reference : Float
    {
        [OdinSerialize] FloatData value;
        public override float GetValue() => value.data;
    }

    class Value : Float
    {
        [OdinSerialize] float value;
        public override float GetValue() => value;
    }

    [OdinSerialize]
    Calculation calculationType;

    [OdinSerialize]
    List<Float> floats;

    public override float data 
    { 
        get
        {
            float val = Calculate();
            // TODO might need work
            if (val != _data)
            {
                _data = val;
                NotifyDataChange();
            }

            return _data;
        }
        set
        {
            float val = Calculate();
            // TODO might need work
            if (val != _data)
            {
                _data = val;
                NotifyDataChange();
            }
        }
    }

    float Calculate()
    {
        if(floats == null || floats.Count == 0 || floats.Any(f => f == null))
        {
            Debug.LogWarning("Error in CalculatedFloat. Value will always be zero.");
            return 0;
        }

        float? result = null;
        Float _float;
        for(int i = 0; i <  floats.Count; i++) 
        {
            _float = floats[i];
            if (result == null)
            {
                result = _float.GetValue();
                continue;
            }

            switch (calculationType)
            {
                case Calculation.Add:
                    result += _float.GetValue();
                    break;

                case Calculation.Subtract:
                    result -= _float.GetValue();
                    break;

                case Calculation.Multiply:
                    result *= _float.GetValue();
                    break;

                case Calculation.Divide:
                    result /= _float.GetValue();
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        return result ?? 0;
    }

#if UNITY_EDITOR
    [OnInspectorInit]
    void Inspector()
    {
        data = Calculate();
    }
#endif
}
