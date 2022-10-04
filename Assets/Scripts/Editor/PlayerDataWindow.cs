using Sirenix.OdinInspector.Editor;
using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using UnityEngine;
using System.Collections.Generic;

public class PlayerDataWindow : OdinMenuEditorWindow
{
    [MenuItem("Windows/ Player data window")]
    private static void OpenWindow()
    {
        GetWindow<PlayerDataWindow>().Show();
    }

    private CreatePlayerData m_createPlayerMovmentData;
    private CreateItems<Weapons> m_createWeaponItems;
    private CreateItems<Shields> m_createShieldsItems;

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();

        m_createPlayerMovmentData = new CreatePlayerData();
        m_createWeaponItems = new CreateItems<Weapons>();
        m_createShieldsItems = new CreateItems<Shields>();


        tree.Add("Create New Player Data", m_createPlayerMovmentData);
        tree.Add("Create new weapons List", m_createWeaponItems);
        tree.Add("Create new shields list", m_createShieldsItems);


        tree.AddAllAssetsAtPath("Palyer data", "Assets/ScriptableObjects/PlayerData/", typeof(PlayerData));
        tree.AddAllAssetsAtPath("Items", "Assets/ScriptableObjects/Items/Weapons/", typeof(Items<Item>));
        tree.AddAllAssetsAtPath("Items", "Assets/ScriptableObjects/Items/Weapons/", typeof(Items<Shield>));

        return tree;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        if (m_createPlayerMovmentData != null)
        {
            DestroyImmediate(m_createPlayerMovmentData.PlayerData);
        }
    }

    protected override void OnBeginDrawEditors()
    {
        OdinMenuTreeSelection odinMenuSelectied = this.MenuTree.Selection;

        SirenixEditorGUI.BeginHorizontalToolbar();
        {
            GUILayout.FlexibleSpace();

            if (SirenixEditorGUI.ToolbarButton("Delete current"))
            {
                PlayerData asset = odinMenuSelectied.SelectedValue as PlayerData;

                string pathToAsset = AssetDatabase.GetAssetPath(asset);
                AssetDatabase.DeleteAsset(pathToAsset);
                AssetDatabase.SaveAssets();
            }
        }
        SirenixEditorGUI.EndHorizontalToolbar();
    }

}
