using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ButtonGetAllThings : MonoBehaviour
{
    [SerializeField] private CellsManager m_cellManager;
    private PlayerInventoryExchnage m_playerEquipmentExchnage;

    protected void Start()
    {
        m_playerEquipmentExchnage = GeneralAccess.Instance.PlayerEquipmentExchange;
    }
    public void GetAllThings()
    {
        List<ItemField> itemFields = m_cellManager.ItemFields.Where(x => !x.IsFree).ToList();

        if (itemFields.Count > m_playerEquipmentExchnage.CellManager.ReturnAmountOfFreeItemField()) // there should be a massage something like: "you dont have enought space in inventory"
            return;

        for (int i = 0; i < itemFields.Count; i++)
        {
            ItemField itemFieldPlayerEquipment = m_playerEquipmentExchnage.CellManager.FindFreeItemField();
            itemFieldPlayerEquipment.SetOccupiedItemField(itemFields[i].GetItemField());

            itemFields[i].SetEmptyItemField();
        }
    }
}
