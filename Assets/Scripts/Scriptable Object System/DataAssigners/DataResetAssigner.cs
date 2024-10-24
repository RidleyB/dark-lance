#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using arg.data;

public static class DataResetAssigner
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void ResetDataObjects()
    {
        string path;
        Object asset;
        foreach (string guid in AssetDatabase.FindAssets("t: SerializedScriptableObject"))
        {
            path = AssetDatabase.GUIDToAssetPath(guid);
            asset = AssetDatabase.LoadAssetAtPath<Object>(path);
            if (asset is not IData)
                continue;

            (asset as IData).ResetData();
        }
    }
}

#endif