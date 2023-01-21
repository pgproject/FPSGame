using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
    [SerializeField] private ObjectToPool m_objectToPool;
    [SerializeField] private Transform m_parentForObject;

    private ObjectPool<ObjectToPool> m_objectPool;

    public ObjectPool<ObjectToPool> ObjectPool => m_objectPool;
    private void Start()
    {
        m_objectPool = new ObjectPool<ObjectToPool>(CreateObject, GetObjFromPool, RealaseObjToPool, DestroyObjInPool);
    }

    private ObjectToPool CreateObject()
    {
        return Instantiate(m_objectToPool, m_parentForObject);
    }

    private void GetObjFromPool(ObjectToPool objectToPool)
    {
        objectToPool.gameObject.SetActive(true);
    }

    private void RealaseObjToPool(ObjectToPool objectToPool)
    {
        objectToPool.gameObject.SetActive(false);
    }

    private void DestroyObjInPool(ObjectToPool objectToPool)
    {
        Destroy(objectToPool.gameObject);
    }
}
