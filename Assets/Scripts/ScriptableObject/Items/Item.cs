using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    [SerializeField] private string m_name;
    public string Name => m_name;

    [SerializeField] private Sprite m_spriteItem;
    public Sprite SpriteItem => m_spriteItem;
}
