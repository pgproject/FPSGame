using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonEquipmentField : MonoBehaviour
{
    [SerializeField] protected ItemField m_itemField;
    protected PlayerEquipmentExchnage m_playerEquipmentExchnage;

    protected virtual void Start()
    {
        m_playerEquipmentExchnage = GeneralAccess.Instance.PlayerEquipmentExchange;
    }

    public abstract void ButtonFieldClick();
}
