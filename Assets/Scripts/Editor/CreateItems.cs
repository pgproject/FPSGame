using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class CreateItems<T> : CreateDataBaseClass where T : Items<Item>
{ 
    [field: SerializeField] public T Items { get; private set; }

    public CreateItems()
    {
        Items = ScriptableObject.CreateInstance<T>();
    }

    [Button("Create list with items"), PropertyOrder(0)]
    protected override void CreateData()
    {
        if (m_scriptableObjectName != string.Empty && m_scriptableObjectPath != string.Empty)
        {
            AssetDatabase.CreateAsset(Items, m_scriptableObjectPath + "/" + m_scriptableObjectName + ASSET_EXTENSION);
            AssetDatabase.SaveAssets();
        }
    }

    

    private IEnumerable<Items<Item>> FindItemClass => TypeCache
       .GetTypesDerivedFrom<Items<Item>>()
       .Select(type => (Items<Item>)Activator.CreateInstance(type));
}
