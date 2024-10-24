using arg;
using arg.data;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;

public class ListDataAssigner : DataAssignerBase
{
    [OdinSerialize]
    IListData listData;

    [OdinSerialize]
    List<UnityEngine.Object> assignmentList;

    [OdinSerialize]
    bool clearOnDestroy = true;

    void Awake()
    {
        foreach(UnityEngine.Object obj in assignmentList)
            listData.Add(obj);
    }

    void OnDestroy()
    {
        if (clearOnDestroy)
            listData.Clear();
    }
}
