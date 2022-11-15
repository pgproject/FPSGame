using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System.IO;
using Sirenix.Serialization;
public class Items<T, U> : CreateDataBaseClass where T : Item where U : ItemObject<T>
{
    private const string PATH_FOR_ITEMS = "Assets/ScriptableObjects/Items/";
    private const string PATH_FOR_ITEMS_OBJECT = "Assets/Prefabs/Items";
    private const string PREFAB_EXTENSION = ".prefab";

    [ShowInInspector, ValueDropdown(nameof(FindItemClass))] public T NewItem { get; private set; }
    [ShowInInspector, ValueDropdown(nameof(FindItemObject))] public Type ItemObject {get; private set;}

    [ShowInInspector, ValueDropdown(nameof(FindComponents))] public Type[] ComponetsToAdd { get; private set; }
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
            //AssetDatabase.CreateAsset(ItemObject as U, PATH_FOR_ITEMS_OBJECT + typeof(T).Name + "/" + m_scriptableObjectName + PREFAB_EXTENSION);
            AssetDatabase.SaveAssets();

        }
        else
        {
            Directory.CreateDirectory(PATH_FOR_ITEMS + typeof(T).Name);
            AssetDatabase.CreateAsset(NewItem, PATH_FOR_ITEMS + typeof(T).Name + "/" + m_scriptableObjectName + ASSET_EXTENSION);
            //AssetDatabase.CreateAsset(NewItemObject, PATH_FOR_ITEMS_OBJECT + typeof(U).Name + "/" + m_scriptableObjectName + PREFAB_EXTENSION);
            AssetDatabase.SaveAssets();
        }

        for (int i = 0; i < ComponetsToAdd.Length; i++)
        {
            //ItemObject.AddComponent(ComponetsToAdd[i]);
        }

    }
    protected virtual IEnumerable<T> FindItemClass => TypeCache
     .GetTypesDerivedFrom<T>()
     .Select(type => (T)Activator.CreateInstance(type));

    private IEnumerable<Type> FindComponents => from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                                 from type in assembly.GetTypes()
                                                 where typeof(Component).IsAssignableFrom(type)
                                                 select type;
    private IEnumerable<Type> FindItemObject => from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                            from type in assembly.GetTypes()
                                            where typeof(U).IsAssignableFrom(type)
                                            select type; 

}
