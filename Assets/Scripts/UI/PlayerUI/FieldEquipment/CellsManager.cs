using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CellsManager : MonoBehaviour
{
    [SerializeField] private List<ItemField> m_itemFields = new List<ItemField>();
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
}
