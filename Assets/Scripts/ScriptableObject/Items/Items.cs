using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Items<T> : ScriptableObject where T : Item
{
    protected const string ASSET_EXTENSION = ".asset";
    [SerializeField, FolderPath(RequireExistingPath = true), Required] protected string m_scriptableObjectPath;

    [SerializeField] private List<T> m_items = new List<T>();
    public List<T> ListOfItems => m_items;

    [SerializeField, FolderPath(RequireExistingPath = true), Required] protected string m_scriptableObjectPathForNewItem;

    [field: SerializeField, ValueDropdown("FindItemClass")] public T NewItem { get; private set; }

    [SerializeField] private string m_newItemName;
    public string NewItemName => m_newItemName;

    [SerializeField] private Sprite m_newItemSprite;
    public Sprite NewSpriteItem => m_newItemSprite;


    [Button("Create item")]
    private void CreateItem()
    {
        if (m_newItemName != string.Empty && m_scriptableObjectPath != string.Empty)
        {
            AssetDatabase.CreateAsset(NewItem, m_scriptableObjectPathForNewItem + "/" + m_newItemName + ASSET_EXTENSION);
            AssetDatabase.SaveAssets();
        }
    }
    private IEnumerable<T> FindItemClass => TypeCache
     .GetTypesDerivedFrom<T>()
     .Select(type => (T)Activator.CreateInstance(type));
}
