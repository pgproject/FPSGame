using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentExchnage : UIObject
{
    private UIObject m_currentOpenInteractableObject;
    public UIObject CurrentOpenInteractableObject => m_currentOpenInteractableObject;
    public void SetCurrentOpenInteractableObject(UIObject openObject)
    {
        m_currentOpenInteractableObject = openObject;
    }

}
