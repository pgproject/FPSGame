using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightData : PlayerData
{
    [SerializeField] private int m_startHp;
    public int StartHp => m_startHp;

}
