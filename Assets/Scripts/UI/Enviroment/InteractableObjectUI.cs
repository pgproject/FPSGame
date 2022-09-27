using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectUI : MonoBehaviour, IInteractableObjectUI
{
    [SerializeField] private GameObject m_panelObject;
    public void Open()
    {
        m_panelObject.SetActive(true);
    }
    public void Close()
    {
        m_panelObject.SetActive(false);
    }
}
