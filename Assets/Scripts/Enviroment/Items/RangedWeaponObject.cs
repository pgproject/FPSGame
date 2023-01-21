using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeaponObject : WeaponObject
{
    [SerializeField] private Pool m_arrowObjectPool;
    public override void Attack()
    {
        Debug.Log(transform.forward);
        Arrow arrow = (Arrow)m_arrowObjectPool.ObjectPool.Get();
        arrow.SetForwardVector(transform.forward);
        arrow.OnGetObjFromPool(arrow.transform.position, Quaternion.Euler(0, 0, 90));
    }

}
