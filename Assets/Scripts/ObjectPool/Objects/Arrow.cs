using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : ObjectToPool
{
    private void OnEnable()
    {
        Debug.Log(transform.forward);
    }

}
