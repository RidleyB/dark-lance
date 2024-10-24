using UnityEngine;

[CreateAssetMenu(menuName = "ARG/Scriptable Objects/Lists/GameObject")]
public class GameObjectListData : ListData<GameObject> 
{
    public void SetActive(IntData a_index)
    {
        if (a_index == null || a_index.data < 0 || a_index.data >= Count)
            return;

        _data[a_index.data].SetActive(true);
    }

    public void SetInactive(IntData a_index)
    {
        if (a_index == null || a_index.data < 0 || a_index.data >= Count)
            return;

        _data[a_index.data].SetActive(false);
    }

    public void SetActiveExclusive(IntData a_index)
    {
        if (a_index == null || a_index.data < 0 || a_index.data >= Count)
            return;

        for (int i = 0; i < _data.Count; i++)
            _data[i].SetActive(a_index.data == i);
    }
}