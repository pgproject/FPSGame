using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCell : MonoBehaviour
{
    [SerializeField, BoxGroup("Eqiupmnet size")] private int m_row;
    [SerializeField, BoxGroup("Eqiupmnet size")] private int m_column;

    [SerializeField, BoxGroup("Size of cell")] private float m_leftMargin;
    [SerializeField, BoxGroup("Size of cell")] private float m_rightMargin;
    [SerializeField, BoxGroup("Size of cell")] private float m_topMargin;
    [SerializeField, BoxGroup("Size of cell")] private float m_bottomMargin;
    [SerializeField] private CellsManager m_cellsManager;

    [SerializeField] private float m_spaceBettwenItemPlace;

    [SerializeField] private GameObject m_objectToCreate;
    [SerializeField] private RectTransform m_parentObject;

    [SerializeField, HideInInspector] private List<GameObject> m_listOfCells = new List<GameObject>();
    public void CreateNewCells()
    {
        int index = 0;
        for (int i = 0; i < m_row; i++)
        {
            for (int j = 0; j < m_column; j++)
            {

                GameObject placeForItem = Instantiate(m_objectToCreate, m_parentObject);

                RectTransform rectTransform = placeForItem.GetComponent<RectTransform>();

                rectTransform.offsetMin = new Vector2(m_leftMargin + (j * m_spaceBettwenItemPlace), m_bottomMargin - (i * m_spaceBettwenItemPlace));
                rectTransform.offsetMax = new Vector2(-m_rightMargin + (j * m_spaceBettwenItemPlace), -m_topMargin - (i * m_spaceBettwenItemPlace));


                ItemField itemField = placeForItem.GetComponentInChildren<ItemField>();
                itemField.SetIndex(index);

                m_cellsManager.AddItemFieldToList(itemField);
                m_listOfCells.Add(placeForItem);
                index++;
            }
        }
    }

    public void DestroyCurrentCells()
    {
        m_listOfCells.ForEach(x => DestroyImmediate(x));
        m_listOfCells.Clear();
        m_cellsManager.ClearList();
    }
}
