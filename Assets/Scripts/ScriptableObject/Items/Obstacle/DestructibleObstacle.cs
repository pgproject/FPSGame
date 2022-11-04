using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObstacle : Obstacle
{
    [SerializeField] private int m_health;
    public int Health => m_health;
}
