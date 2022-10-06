using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObjectInventory : UIObject
{
    [SerializeField] protected CellsManager m_cellManager;
    public CellsManager CellManager => m_cellManager;
}
