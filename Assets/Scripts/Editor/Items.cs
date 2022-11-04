using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System.IO;

public class Items<T> : CreateDataBaseClass where T : Item
{
    private const string m_pathForItems = "Assets/ScriptableObjects/Items/";

    [field: SerializeField, ValueDropdown("FindItemClass")] public T NewItem { get; private set; }

    public Items()
    {
        NewItem = ScriptableObject.CreateInstance<T>();
    }

    [Button("Create item")]
    protected override void CreateData()
    {
        if (Directory.Exists(m_pathForItems + typeof(T).Name) && m_scriptableObjectName != string.Empty)
        {
            AssetDatabase.CreateAsset(NewItem, m_pathForItems + typeof(T).Name + "/" + m_scriptableObjectName + ASSET_EXTENSION);
            NewItem.SetName(m_scriptableObjectName);
            AssetDatabase.SaveAssets();
        }
        else
        {
            Directory.CreateDirectory(m_pathForItems + typeof(T).Name);
            AssetDatabase.CreateAsset(NewItem, m_pathForItems + typeof(T).Name + "/" + m_scriptableObjectName + ASSET_EXTENSION);
            NewItem.SetName(m_scriptableObjectName);
            AssetDatabase.SaveAssets();
        }
    }
    protected virtual IEnumerable<T> FindItemClass => TypeCache
     .GetTypesDerivedFrom<T>()
     .Select(type => (T)Activator.CreateInstance(type));
}
