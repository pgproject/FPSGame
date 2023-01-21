using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemObject<T> : MonoBehaviour where T : Item
{
    public string NameObject => gameObject.name;

    [SerializeField, PreviewField(75, ObjectFieldAlignment.Left), PropertyOrder(1)] private Sprite m_spriteItem;
    public Sprite SpriteItem => m_spriteItem;

    [SerializeField, PreviewField(75, ObjectFieldAlignment.Left), PropertyOrder(2)] private Mesh m_meshObject;
    public Mesh MeshObject => m_meshObject;
    [SerializeField] private MeshRenderer m_objectMeshRenderer;
    [SerializeField] private Image m_objectImage;

    private bool m_objectIsInEquipment;
    public bool ObjectIsInEquipment => m_objectIsInEquipment;

    public void SetPreporties(Sprite sprite, Mesh mesh, Material meshMaterial, Material spriteMaterial)
    {
        m_spriteItem = sprite;
        m_meshObject = mesh;
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();


        MeshFilter mesh1 = GetComponent<MeshFilter>();
        mesh1.mesh = mesh;
        MeshRenderer mesh2 = GetComponent<MeshRenderer>();
        mesh2.material = meshMaterial;
    }
    
    public void ChangeStateOfItem(bool itemInEquipment)
    {
        m_objectIsInEquipment = itemInEquipment;

        m_objectMeshRenderer.enabled = !itemInEquipment;
        m_objectImage.enabled = itemInEquipment;

    }
}
