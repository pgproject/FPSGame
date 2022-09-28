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

    [SerializeField] private float m_spaceBettwenItemPlace;

    [SerializeField] private GameObject m_objectToCreate;
    [SerializeField] private RectTransform m_parentObject;

    private List<GameObject> m_listOfCells = new List<GameObject>();
    public void CreateNewCells()
    {
        for (int i = 0; i < m_column; i++)
        {
            for (int j = 0; j < m_row; j++)
            {
                GameObject placeForItem = Instantiate(m_objectToCreate, m_parentObject);

                RectTransform rectTransform = placeForItem.GetComponent<RectTransform>();

                rectTransform.offsetMin = new Vector2(m_leftMargin + (i * m_spaceBettwenItemPlace), m_bottomMargin - (j * m_spaceBettwenItemPlace));
                rectTransform.offsetMax = new Vector2(-m_rightMargin + (i * m_spaceBettwenItemPlace), -m_topMargin - (j * m_spaceBettwenItemPlace));
                m_listOfCells.Add(placeForItem);
            }
           
        }
    }

    public void DestroyCurrentCells()
    {
            m_listOfCells.ForEach(x => DestroyImmediate(x));
            m_listOfCells.Clear();
    }
}
