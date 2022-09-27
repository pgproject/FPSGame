using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractableObject
{
    
    [SerializeField] private InteractableObjectUI m_interactableObjectUI;
    
    private bool m_isClose = true;
    private PlayerEquipmentExchnage m_playerEquipmentExchnage;

    private void Start()
    {
        m_playerEquipmentExchnage = GeneralAccess.Instance.PlayerEquipmentExchange;
    }

    public void Interact()
    {
        if (m_isClose)
        {
            m_isClose = false;
            m_interactableObjectUI.Open();
            m_playerEquipmentExchnage.Open();
        }
        else
        {
            m_isClose = true;
            m_interactableObjectUI.Close();
            m_playerEquipmentExchnage.Close();
        }
    }

    

   
}
