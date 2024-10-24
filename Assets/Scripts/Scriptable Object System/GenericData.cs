using arg.data;
using UnityEngine;

[CreateAssetMenu(menuName = "ARG/Data/Object")]
public class GenericData : DataObject<object> 
{
    public T As<T>()
    {
        return (T)data;
    }
}