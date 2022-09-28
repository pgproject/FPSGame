using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlayerEquipmentField : ButtonEquipmentField
{
    public override void ButtonFieldClick()
    {
        ItemField itemFieldInBox = m_playerEquipmentExchnage.CurrentOpenInteractableObject.CellManager.FindFreeItemField();
        itemFieldInBox.SetOccupiedItemField(m_itemField.GetItemField());

        m_itemField.SetEmptyItemField();
    }
}
