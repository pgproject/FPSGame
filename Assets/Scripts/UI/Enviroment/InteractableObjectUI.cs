using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectUI : MonoBehaviour
{
    [SerializeField] private GameObject m_panelObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
        m_panelObject.SetActive(true);
    }
    public void Close()
    {
        m_panelObject.SetActive(false);
    }
}
