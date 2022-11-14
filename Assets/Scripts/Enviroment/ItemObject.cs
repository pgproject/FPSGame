using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemObject<T> : MonoBehaviour where T : Item
{
    [ReadOnly, SerializeField] private string m_nameObject;
    public string NameObject => m_nameObject;

    [SerializeField, PreviewField(75, ObjectFieldAlignment.Left), PropertyOrder(1)] private Sprite m_spriteItem;
    public Sprite SpriteItem => m_spriteItem;

    [SerializeField, PreviewField(75, ObjectFieldAlignment.Left), PropertyOrder(2)] private Mesh m_meshObject;
    public Mesh MeshObject => m_meshObject;
    [SerializeField] private MeshRenderer m_objectMeshRenderer;
    [SerializeField] private Image m_objectImage;

    private bool m_objectIsInEquipment;
    public bool ObjectIsInEquipment => m_objectIsInEquipment;

    public void SetPreporties(string name, Sprite sprite, Mesh mesh)
    {
        m_nameObject = name;
        gameObject.name = m_nameObject;
        m_spriteItem = sprite;
        m_meshObject = mesh;
    }
    
    public void ChangeStateOfItem(bool itemInEquipment)
    {
        m_objectIsInEquipment = itemInEquipment;

        m_objectMeshRenderer.enabled = !itemInEquipment;
        m_objectImage.enabled = itemInEquipment;

    }
}
