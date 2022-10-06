using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryExchnage : UIObjectInventory
{
    private UIObjectInventory m_currentOpenInteractableObject;
    public UIObjectInventory CurrentOpenInteractableObject => m_currentOpenInteractableObject;
    public void SetCurrentOpenInteractableObject(UIObjectInventory openObject)
    {
        m_currentOpenInteractableObject = openObject;
    }

}
