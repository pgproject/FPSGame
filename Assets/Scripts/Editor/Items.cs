using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System.IO;

public class Items<T, U> : CreateDataBaseClass where T : Item where U : ItemObject<T>
{
    private const string PATH_FOR_ITEMS = "Assets/ScriptableObjects/Items/";
    private const string PATH_FOR_ITEMS_OBJECT = "Assets/Prefabs/Items";
    private const string PREFAB_EXTENSION = ".prefab";

    [field: SerializeField, ValueDropdown(nameof(FindItemClass))] public T NewItem { get; private set; }
    [field: SerializeField, ValueDropdown(nameof(Components))] public Type[] NewItemObject;
    public Items()
    {
        NewItem = ScriptableObject.CreateInstance<T>();
    }

    [Button("Create item")]
    protected override void CreateData()
    {
        if (Directory.Exists(PATH_FOR_ITEMS + typeof(T).Name) && m_scriptableObjectName != string.Empty)
        {
            AssetDatabase.CreateAsset(NewItem, PATH_FOR_ITEMS + typeof(T).Name + "/" + m_scriptableObjectName + ASSET_EXTENSION);
            //AssetDatabase.CreateAsset(NewItemObject, PATH_FOR_ITEMS_OBJECT + typeof(U).Name + "/" + m_scriptableObjectName + PREFAB_EXTENSION);
            AssetDatabase.SaveAssets();
        }
        else
        {
            Directory.CreateDirectory(PATH_FOR_ITEMS + typeof(T).Name);
            AssetDatabase.CreateAsset(NewItem, PATH_FOR_ITEMS + typeof(T).Name + "/" + m_scriptableObjectName + ASSET_EXTENSION);
            //AssetDatabase.CreateAsset(NewItemObject, PATH_FOR_ITEMS_OBJECT + typeof(U).Name + "/" + m_scriptableObjectName + PREFAB_EXTENSION);
            AssetDatabase.SaveAssets();
        }
    }
    protected virtual IEnumerable<T> FindItemClass => TypeCache
     .GetTypesDerivedFrom<T>()
     .Select(type => (T)Activator.CreateInstance(type));

    private IEnumerable<Type> Components => from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                                 from type in assembly.GetTypes()
                                                 where typeof(Component).IsAssignableFrom(type)
                                                 select type;
}
