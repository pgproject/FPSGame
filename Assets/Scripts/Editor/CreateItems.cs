using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class CreateItems<TItems, TItem> : CreateDataBaseClass where TItems : Items<TItem>
                                                              where TItem : Item
{ 
    [field: SerializeField] public TItems Items { get; private set; }

    public CreateItems()
    {
        Items = ScriptableObject.CreateInstance<TItems>();
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
