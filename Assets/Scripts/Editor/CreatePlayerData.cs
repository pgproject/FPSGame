using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using System;

public class CreatePlayerData
{
    private const string ASSET_EXTENSION = ".asset";
    [SerializeField, Required] private string m_scriptableObjectName;
    [SerializeField, FolderPath(RequireExistingPath = true), Required] private string m_scriptableObjectPath;
    [field: SerializeField, ValueDropdown("FindPlayerDataClass", AppendNextDrawer = true)] public PlayerData PlayerData { get; private set; }


    public string SciptableObjectPath => m_scriptableObjectPath;
    public CreatePlayerData()
    {
        PlayerData = ScriptableObject.CreateInstance<PlayerData>();
    }

    [Button("Add new player movment data")]
    private void CreateNewPlayerMovmentData()
    {
        if (m_scriptableObjectName != string.Empty && m_scriptableObjectPath != string.Empty)
        {
            AssetDatabase.CreateAsset(PlayerData, m_scriptableObjectPath + "/" + m_scriptableObjectName + ASSET_EXTENSION);
            AssetDatabase.SaveAssets();
        }
    }

    private IEnumerable<PlayerData> FindPlayerDataClass => TypeCache
        .GetTypesDerivedFrom<PlayerData>()
        .Select(type => (PlayerData)Activator.CreateInstance(type));
}
