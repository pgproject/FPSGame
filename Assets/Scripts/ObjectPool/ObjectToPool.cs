using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToPool : MonoBehaviour
{
    public void SetForwardVector(Vector3 forwardVector)
    {
        transform.forward = forwardVector;
    }

    public void OnGetObjFromPool(Vector3 position, Quaternion rotation)
    {
        transform.localPosition = position;
        transform.localRotation = rotation;
    }
}
