using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectUI : UIObject
{
    private PlayerEquipmentExchnage m_playerEquipmentExchnage;
    private void Start()
    {
        m_playerEquipmentExchnage = GeneralAccess.Instance.PlayerEquipmentExchange;
    }
    public override void Open()
    {
        base.Open();
        m_playerEquipmentExchnage.SetCurrentOpenInteractableObject(this);
    }
    public override void Close()
    {
        base.Close();
        m_playerEquipmentExchnage.SetCurrentOpenInteractableObject(null);
    }
}
