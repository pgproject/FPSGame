using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;
using System;

public abstract class Item : ScriptableObject
{
    [ShowInInspector, ReadOnly, PropertyOrder(-1)] public string ObjectName => name;
    [ShowInInspector, ReadOnly, PropertyOrder(-1)] private Item m_item => this;

    [SerializeField, PreviewField(75, ObjectFieldAlignment.Left), PropertyOrder(1)] private Sprite m_spriteItem;
    public Sprite SpriteItem => m_spriteItem;

    [SerializeField] private GameObject m_prefabObject;
    public GameObject PrefabObject => m_prefabObject;

    [SerializeField, PreviewField(75, ObjectFieldAlignment.Left), PropertyOrder(2)] private Mesh m_meshObject;
    public Mesh MeshObject => m_meshObject;
    [SerializeField] private Material m_meshMaterial;
    public Material MeshMaterial => m_meshMaterial;
    [SerializeField] private Material m_spriteMaterial;
    public Material SpriteMaterial => m_spriteMaterial;



    public void SetPreporties(Mesh mesh, Sprite sprite, Material meshMaterial, Material spriteMaterial, GameObject prefab)
    {
        m_meshObject = mesh;
        m_spriteItem = sprite;
        m_meshMaterial = meshMaterial;
        m_spriteMaterial = spriteMaterial;
        m_prefabObject = prefab;
    }
}
