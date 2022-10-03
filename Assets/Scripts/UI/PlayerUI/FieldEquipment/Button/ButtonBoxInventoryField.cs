using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBoxInventoryField : ButtonInventoryField
{
    public override void ButtonFieldClick()
    {
        if (m_itemField.GetItemField() == null) return;

        ItemField itemFieldInPlayerEquipment = m_playerEquipmentExchnage.CellManager.FindFreeItemField();
        itemFieldInPlayerEquipment.SetOccupiedItemField(m_itemField.GetItemField());

        m_itemField.SetEmptyItemField();
    }
}
