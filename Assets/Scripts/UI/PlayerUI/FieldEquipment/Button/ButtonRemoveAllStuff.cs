using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonRemoveAllStuff : MonoBehaviour
{

    [SerializeField] private CellsManager m_cellManager;
    private PlayerInventoryExchnage m_playerEquipmentExchnage;

    protected void Start()
    {
        m_playerEquipmentExchnage = GeneralAccess.Instance.PlayerEquipmentExchange;
    }
    public void RemoveAllStaff()
    {
        List<ItemField> itemFields = m_playerEquipmentExchnage.CellManager.ItemFields.Where(x => !x.IsFree).ToList();

        if (itemFields.Count > m_cellManager.ReturnAmountOfFreeItemField()) // there should be a massage something like: "you dont have enought space in inventory"
            return;

        for (int i = 0; i < itemFields.Count; i++)
        {
            ItemField itemFieldPlayerEquipment = m_playerEquipmentExchnage.CurrentOpenInteractableObject.CellManager.FindFreeItemField();
            itemFieldPlayerEquipment.SetOccupiedItemField(itemFields[i].GetItemField());

            itemFields[i].SetEmptyItemField();
        }
    }
}
