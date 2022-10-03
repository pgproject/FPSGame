using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CellsManager : MonoBehaviour
{
    [SerializeField] private List<ItemField> m_itemFields = new List<ItemField>();
    public List<ItemField> ItemFields => m_itemFields;
    public void AddItemFieldToList(ItemField itemField)
    {
        m_itemFields.Add(itemField);
    }

    public ItemField FindFreeItemField()
    {
        return m_itemFields.Find(x => x.IsFree);
    }
    public void ClearList()
    {
        m_itemFields.Clear();
    }

    public int ReturnAmountOfFreeItemField()
    {
        int amountOfFreeItemField = 0;
        for (int i = 0; i < m_itemFields.Count; i++)
        {
            if (m_itemFields[i].IsFree)
            {
                amountOfFreeItemField++;
            }
        }
        return amountOfFreeItemField;
    }
}
