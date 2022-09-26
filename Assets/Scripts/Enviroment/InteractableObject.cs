using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractableObject
{
    [SerializeField] private InteractableObjectUI m_interactableObjectUI;
    private bool m_isClose = true;

    
    public void Interact()
    {
        if (m_isClose)
        {
            m_isClose = false;
            m_interactableObjectUI.Open();
        }
        else
        {
            m_isClose = true;
            m_interactableObjectUI.Close();
        }
    }

    

    private void Start()
    {

    }

    private void Update()
    {

    }
   
}
