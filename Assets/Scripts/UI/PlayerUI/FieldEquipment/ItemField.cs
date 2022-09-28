using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemField : MonoBehaviour
{
    [SerializeField] private int m_index;

    [SerializeField] private Image m_fieldImage;
    private bool m_isFree => m_fieldImage.sprite == null;

    public bool IsFree => m_isFree;
    public int Index => m_index;
    void Start()
    {
        if (m_fieldImage.sprite == null)
        {
            m_fieldImage.color = new Color(1, 1, 1, 0); 
        }
    }

    public void SetIndex(int index)
    {
        m_index = index;
    }

    public void SetOccupiedItemField(Sprite fieldSprite)
    {
        m_fieldImage.sprite = fieldSprite;
        m_fieldImage.color = new Color(1, 1, 1, 1);
    }
    public void SetEmptyItemField()
    {
        m_fieldImage.sprite = null;
        m_fieldImage.color = new Color(1, 1, 1, 0);
    }
    public Sprite GetItemField()
    {
        return m_fieldImage.sprite;
    }
}
