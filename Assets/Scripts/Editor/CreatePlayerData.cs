using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using System;

public class CreatePlayerData : CreateDataBaseClass
{
    [field: SerializeField, ValueDropdown("FindPlayerDataClass", AppendNextDrawer = true)] public PlayerData PlayerData { get; private set; }
    public CreatePlayerData()
    {
        PlayerData = ScriptableObject.CreateInstance<PlayerData>();
    }

    [Button("Add new player movment data")]
    protected override void CreateData()
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
