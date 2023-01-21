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
    [ShowInInspector, ValueDropdown(nameof(FindItemObject)), Required] private Type m_itemObject;
    [ShowInInspector, ValueDropdown(nameof(FindComponents))] private Type[] m_componetsToAdd;

    [ShowInInspector, PreviewField(75, ObjectFieldAlignment.Left)] private Mesh m_meshObject;
    [ShowInInspector, PreviewField(75, ObjectFieldAlignment.Left)] private Sprite m_spriteObject;
    [ShowInInspector] private Material m_meshMaterial;
    [ShowInInspector] private Material m_spriteMaterial;
    
    public Items()
    {
        NewItem = ScriptableObject.CreateInstance<T>();
    }

    [Button("Create item")]
    protected override void CreateData()
    {
        if (!Directory.Exists(PATH_FOR_ITEMS + typeof(T).Name))
        {
            Directory.CreateDirectory(PATH_FOR_ITEMS + typeof(T).Name);
        }
        if (!Directory.Exists(PATH_FOR_ITEMS_OBJECT + typeof(T).Name))
        {
            Directory.CreateDirectory(PATH_FOR_ITEMS_OBJECT + typeof(T).Name);

        }
        GameObject itemObject = GameObject.Instantiate(new GameObject());

        if (m_scriptableObjectName != string.Empty)
        {
            var prefab = PrefabUtility.SaveAsPrefabAsset(itemObject, PATH_FOR_ITEMS_OBJECT + typeof(T).Name + "/" + m_scriptableObjectName + PREFAB_EXTENSION);

            prefab.AddComponent(m_itemObject);
            for (int i = 0; i < m_componetsToAdd.Length; i++)
            {
                prefab.AddComponent(m_componetsToAdd[i]);
            }
            prefab.GetComponent<U>().SetPreporties(m_spriteObject, m_meshObject, m_meshMaterial, m_spriteMaterial);
            
            AssetDatabase.CreateAsset(NewItem, PATH_FOR_ITEMS + typeof(T).Name + "/" + m_scriptableObjectName + ASSET_EXTENSION);


            NewItem.SetPreporties(m_meshObject, m_spriteObject, m_meshMaterial, m_spriteMaterial, prefab);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
    protected virtual IEnumerable<T> FindItemClass => TypeCache
     .GetTypesDerivedFrom<T>()
     .Select(type => (T)Activator.CreateInstance(type));

    private IEnumerable<Type> FindComponents => from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                                from type in assembly.GetTypes()
                                                where typeof(Component).IsAssignableFrom(type) 
                                                && !typeof(U).IsAssignableFrom(type)
                                                && !typeof(ItemObject<>).IsAssignableFrom(type)
                                                select type;
    private IEnumerable<Type> FindItemObject => from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                            from type in assembly.GetTypes()
                                            where typeof(U).IsAssignableFrom(type)
                                            select type; 
}
