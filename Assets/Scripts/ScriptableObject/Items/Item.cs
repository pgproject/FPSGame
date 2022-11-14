using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;


public abstract class Item : ScriptableObject
{
    [ShowInInspector ,ReadOnly, PropertyOrder(-1)] public string ObjectName => name;

    [SerializeField, PreviewField(75, ObjectFieldAlignment.Left), PropertyOrder(1)] private Sprite m_spriteItem;
    public Sprite SpriteItem => m_spriteItem;

    [SerializeField] private GameObject m_prefabObject;
    public GameObject PrefabObject => m_prefabObject;

    [SerializeField] private ItemObject<Item> m_itemObject;
    public ItemObject<Item> ItemObject => m_itemObject;

    [SerializeField, PreviewField(75, ObjectFieldAlignment.Left), PropertyOrder(2)] private Mesh m_meshObject;
    public Mesh MeshObject => m_meshObject;
}
