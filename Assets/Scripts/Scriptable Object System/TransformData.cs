using arg.data;
using UnityEngine;

[CreateAssetMenu(menuName = "ARG/Data/Transform")]
public class TransformData : DataObject<Transform> 
{
    public void SetActive(bool a_active)
    {
        if (_data == null)
            return;

        _data.gameObject.SetActive(a_active);
    }
}