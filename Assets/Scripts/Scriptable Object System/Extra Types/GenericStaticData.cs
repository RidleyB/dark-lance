using arg.data;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(menuName = "ARG/Scriptable Objects/Generic Static")]
public class GenericStaticData : DataObject<object>
{
    [ValueDropdown("GetStaticTypes")]
    [OnValueChanged("SetAssemblyQualifiedType")]
    [OdinSerialize]
    string selectedStaticClassName;
    string assemblyQualifiedTypeName;

    [ValueDropdown("GetStaticClassProperties")]
    [OnValueChanged("SetDataFromStaticValue")]
    [OdinSerialize]
    string selectedPropertyName;

    public override object data 
    { 
        get => GetStaticValue(); 
        set
        {
            if (GetStaticValue() != value)
            {
                SetStaticValue(value);
                NotifyDataChange();
            }
        }
    }

    void SetAssemblyQualifiedType()
    {
        assemblyQualifiedTypeName = Type.GetType(selectedStaticClassName).AssemblyQualifiedName;
    }

    object GetStaticValue()
    {
        if (Type.GetType(assemblyQualifiedTypeName) == null)
            return default;

        Type type = Type.GetType(assemblyQualifiedTypeName);
        return type.GetProperty(selectedPropertyName).GetValue(null);
    }

    void SetStaticValue(object a_value)
    {
        if (Type.GetType(assemblyQualifiedTypeName) == null)
            return;

        Type type = Type.GetType(assemblyQualifiedTypeName);
        type.GetProperty(selectedPropertyName).SetValue(null, a_value);
        _data = a_value;
    }

    void SetDataFromStaticValue()
    {
        if (Type.GetType(assemblyQualifiedTypeName) == null)
            return;

        Type type = Type.GetType(assemblyQualifiedTypeName);
        _data = type.GetProperty(selectedPropertyName).GetValue(null);
    }

    IEnumerable<string> GetStaticClassProperties()
    {
        if (Type.GetType(assemblyQualifiedTypeName) == null)
            yield break;

        Type type = Type.GetType(assemblyQualifiedTypeName);
        foreach (PropertyInfo propertyInfo in type.GetProperties(BindingFlags.Public | BindingFlags.Static))
            yield return propertyInfo.Name;
    }

    IEnumerable<string> GetStaticTypes()
    {
        foreach(Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach(Type type in assembly.GetTypes())
            {
                if (type.IsStatic() && !assembly.FullName.ToLower().Contains("unity"))
                    yield return type.Name;
            }
        }
    }
}
