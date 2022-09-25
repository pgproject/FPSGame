using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovmentData : PlayerData
{
    [SerializeField] private float m_walkSpeed;
    public float WalkSpeed => m_walkSpeed;

}
