using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralAccess : MonoBehaviour
{
    public static GeneralAccess Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    [SerializeField] private PlayerFightData m_playerFightData;
    public PlayerFightData PlayerFightData => m_playerFightData;

    [SerializeField] private PlayerMovmentData m_playerMovmentData;
    public PlayerMovmentData PlayerMovmentData => m_playerMovmentData;

    [SerializeField] private PlayerEquipmentExchnage m_playerEquipmentExchange;
    public PlayerEquipmentExchnage PlayerEquipmentExchange => m_playerEquipmentExchange;

    [SerializeField] private GameManager m_gameManager;
    public GameManager GameManager => m_gameManager;
 
}
