using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIObject : MonoBehaviour, IUIObject
{
    [SerializeField] protected GameObject m_panelObject;
   
    public virtual void Open()
    {
        m_panelObject.SetActive(true);
    }
    public virtual void Close()
    {
        m_panelObject.SetActive(false);
    }
}
