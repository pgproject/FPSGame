using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCell : MonoBehaviour
{
    [SerializeField] private int m_row;
    [SerializeField] private int m_colmn;

    [SerializeField] private float m_leftMargin;
    [SerializeField] private float m_rightMargin;
    [SerializeField] private float m_topMargin;
    [SerializeField] private float m_bottomMargin;

    [SerializeField] private RectTransform m_rectTransformObject;
    [SerializeField] private GameObject m_objectToCreate;
    [SerializeField] private RectTransform m_parentObject;

    private List<GameObject> m_listOfCells = new List<GameObject>();

    private float m_sizeDeltaX;
    private float m_sizeDeltaY;
    private void Start()
    {
        

    }

    public void CreateNewCells()
    {
        m_sizeDeltaX = m_rectTransformObject.sizeDelta.x;
        m_sizeDeltaY = m_rectTransformObject.sizeDelta.y;


        //m_objectToCreate.GetComponent<RectTransform>().offsetMax = new Vector2(m_rightMargin, m_topMargin);
        //m_objectToCreate.GetComponent<RectTransform>().offsetMin = new Vector2(m_leftMargin, m_bottomMargin);


        float spaceBettwenLineY = m_sizeDeltaY / m_row;
        float currentYPosition = 0;

        while (currentYPosition < m_sizeDeltaY)
        {
            currentYPosition += spaceBettwenLineY;

            GameObject newObject = Instantiate(m_objectToCreate.gameObject, m_parentObject);

            RectTransform rectTransformNewObj = newObject.GetComponent<RectTransform>();

            rectTransformNewObj.offsetMax = new Vector2(m_rightMargin, m_topMargin - currentYPosition);
            rectTransformNewObj.offsetMin = new Vector2(m_leftMargin, m_bottomMargin - currentYPosition);
            m_listOfCells.Add(newObject);
        }
    }

    public void DestroyCurrentCells()
    {
            m_listOfCells.ForEach(x => DestroyImmediate(x));
            m_listOfCells.Clear();
    }
}
