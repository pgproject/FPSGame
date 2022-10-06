using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemField : MonoBehaviour
{
    [SerializeField] private int m_index;

    [SerializeField] private Image m_fieldImage;
    [SerializeField] private Item m_item;

    private bool m_isFree => m_item == null;

    public bool IsFree => m_isFree;
    public int Index => m_index;
    void Start()
    {
        if (m_item == null)
        {
            m_fieldImage.color = new Color(1, 1, 1, 0); 
        }
        else
        {
            m_fieldImage.color = new Color(1, 1, 1, 1);
            m_fieldImage.sprite = m_item.SpriteItem;
        }
    }

    public void SetIndex(int index)
    {
        m_index = index;
    }

    public void SetOccupiedItemField(Item item)
    {
        m_item = item;
        m_fieldImage.sprite = item.SpriteItem;
        m_fieldImage.color = new Color(1, 1, 1, 1);
    }
    public void SetEmptyItemField()
    {
        m_item = null;
        m_fieldImage.sprite = null;
        m_fieldImage.color = new Color(1, 1, 1, 0);
    }
    public Item GetItemField()
    {
        return m_item;
    }
}
