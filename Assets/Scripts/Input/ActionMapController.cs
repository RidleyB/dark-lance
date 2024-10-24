using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class ActionMapController : SerializedMonoBehaviour
{
    [OdinSerialize]
    InputActionAsset inputAsset;

    [ValueDropdown(nameof(GetMaps))]
    [OdinSerialize]
    string selectedAsset;

    [DisableIf("@true")]
    [OdinSerialize]
    InputActionMap actionMap;

    void OnEnable()
    {
        actionMap = GetMap(selectedAsset);

        if (!inputAsset.enabled)
            inputAsset.Enable();

        actionMap.Enable();
    }

    void OnDisable() 
    { 
        actionMap.Disable();
    }

#if UNITY_EDITOR
    IEnumerable<string> GetMaps()
    {
        foreach (InputActionMap actionMap in inputAsset.actionMaps)
            yield return actionMap.name;
    }

    void OnMapSelected(string a_selectedMap)
    {
        if (string.IsNullOrEmpty(a_selectedMap))
            return;

        GetMap(a_selectedMap);
    }

    InputActionMap GetMap(string a_selectedMap)
    {
        foreach (InputActionMap map in inputAsset.actionMaps)
        {
            if (map.name == a_selectedMap)
            {
                selectedAsset = a_selectedMap;
                return map;
            }
        }

        return null;
    }
#endif
}
