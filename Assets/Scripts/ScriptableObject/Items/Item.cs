using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;

public class Item : ScriptableObject
{
    [ReadOnly, SerializeField] private string m_name;
    public string Name => m_name;

    [SerializeField] private Sprite m_spriteItem;
    public Sprite SpriteItem => m_spriteItem;

    public void SetName(string name)
    {
        m_name = name;
    }
}
