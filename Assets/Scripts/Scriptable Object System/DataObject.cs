using arg.events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace arg.data
{
    public enum ResetType
    {
        None = 0,
        Value = 1,
        Default = 2,
    }

    public abstract class DataObject<T> : SerializedScriptableObject, IData
    {
        [Title("Debug")]
        [Tooltip("Brief description of the object")]
        [OdinSerialize]
        [HideLabel]
        [TextArea]
        string editorTooltip = "Brief description goes here.";

        [Title("Value")]
        [VerticalGroup("Value")]
        [HideLabel]
        [OnValueChanged("NotifyDataChange")]
        [OdinSerialize]
        protected T _data;

        [Header("Reset")]
        [VerticalGroup("Value/Reset")]
        [OdinSerialize]
        [InfoBox("@GetResetDataInfoString()")]
        protected ResetType resetType;

        [VerticalGroup("Value/Reset")]
        [ShowIf("@resetType == ResetType.Value")]
        [HideLabel]
        [OdinSerialize]
        protected T _resetData;

        [Title("On Value Changed")]
        [VerticalGroup("OVC")]
        [HideLabel]
        [OdinSerialize]
        protected EventObject _onValueChanged;
        public EventObject onValueChanged => _onValueChanged;

        public virtual T data
        {
            get => _data;
            set
            {
                if ((_data != null && !object.ReferenceEquals(_data, value)) || (_data == null && value != null))
                {
                    _data = value;
                    NotifyDataChange();
                }
            }
        }

        void Start()
        { 
            ResetData();
        }

        public object GetData()
        {
            return _data;
        }

        public void SetData(object a_data, bool a_notify = true)
        {
            if (!a_notify)
            {
                _data = (T)a_data;
                return;
            }

            if ((_data != null && !object.ReferenceEquals(_data, a_data)) || (data == null && a_data != null))
            {
                _data = (T)a_data;
                NotifyDataChange();
            }
        }

        public Type GetDataType()
        {
            return typeof(T);
        }

        public void NotifyDataChange()
        {
            if (_onValueChanged == null)
                return;

            _onValueChanged.Invoke();
        }

        public void ClearData(bool a_notify = true)
        {
            SetData(default, a_notify);
        }

        public void ResetData()
        {
            switch (resetType)
            {
                default:
                case ResetType.None:
                    return;

                case ResetType.Default:
                    // cast needed so null isn't passed for managed types
                    SetData((T)default); 
                    break;

                case ResetType.Value:
                    SetData(GetResetData());
                    break;
            }
        }

        public virtual T GetResetData() => _resetData;


#if UNITY_EDITOR
        string GetResetDataInfoString()
        {
            string value;
            switch (resetType)
            {
                default:
                case ResetType.None:
                    return $"Value will remain as-is.";

                case ResetType.Value:
                    value = _resetData == null ? "null" : $"{_resetData}";
                    return $"Data will be set to the value specified below ({value}):";

                case ResetType.Default:
                    value = (T)default == null ? "null" : $"{(T)default}";
                    return $"Data will be set to: {value}";
            }
        }

        [VerticalGroup("OVC")]
        [ButtonGroup("OVC/Event")]
        [Button("+")]
        void AddEvent()
        {
            string assetPath = AssetDatabase.GetAssetPath(this);
            List<UnityEngine.Object> childAssets = new List<UnityEngine.Object>(AssetDatabase.LoadAllAssetsAtPath(assetPath));
            if (onValueChanged != null || childAssets.Count > 1)
                return;

            _onValueChanged = CreateInstance<EventObject>();
            _onValueChanged.name = "onValueChanged";

            AssetDatabase.AddObjectToAsset(_onValueChanged, assetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        [VerticalGroup("OVC")]
        [ButtonGroup("OVC/Event")]
        [Button("-")]
        void RemoveEvent()
        {
            string assetPath = AssetDatabase.GetAssetPath(this);
            List<UnityEngine.Object> childAssets = new List<UnityEngine.Object>(AssetDatabase.LoadAllAssetsAtPath(assetPath));
            if (_onValueChanged == null || childAssets.Count == 1)
                return;

            foreach (UnityEngine.Object asset in childAssets)
            {
                if (AssetDatabase.IsMainAsset(asset))
                    continue;

                AssetDatabase.RemoveObjectFromAsset(asset);
                string newAssetPath = $"{assetPath.Substring(0, assetPath.LastIndexOf('/'))}/{name}_{asset.name}.asset";
                AssetDatabase.CreateAsset(asset, newAssetPath);
            }

            _onValueChanged = null;
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
#endif
    }
}