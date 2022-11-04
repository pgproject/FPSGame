using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [ReadOnly, SerializeField] private string m_name;
    public string Name => m_name;

    [SerializeField, PreviewField(75, ObjectFieldAlignment.Left), PropertyOrder(1)] private Sprite m_spriteItem;
    public Sprite SpriteItem => m_spriteItem;

    [SerializeField] private GameObject m_prefabObject;
    public GameObject PrefabObject => m_prefabObject;

    [SerializeField, PreviewField(75, ObjectFieldAlignment.Left), PropertyOrder(2)] private Mesh m_meshObject;
    public Mesh MeshObject => m_meshObject;

    public void SetName(string name)
    {
        m_name = name;
    }
}
