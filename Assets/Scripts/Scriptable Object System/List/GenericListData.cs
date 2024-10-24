using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ARG/Scriptable Objects/Lists/Generic")]
public class GenericListData : ListData<Object> 
{
    public IEnumerable<T> As<T>() where T : Object
    {
        foreach (Object obj in _data)
            yield return obj as T;
    }
}
