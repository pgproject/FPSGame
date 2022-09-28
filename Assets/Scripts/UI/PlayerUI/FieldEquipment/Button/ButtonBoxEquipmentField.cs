using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBoxEquipmentField : ButtonEquipmentField
{
    public override void ButtonFieldClick()
    {
        ItemField itemFieldInPlayerEquipment = m_playerEquipmentExchnage.CellManager.FindFreeItemField();
        itemFieldInPlayerEquipment.SetOccupiedItemField(m_itemField.GetItemField());

        m_itemField.SetEmptyItemField();
    }
}
