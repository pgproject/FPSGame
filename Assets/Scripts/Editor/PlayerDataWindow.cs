using Sirenix.OdinInspector.Editor;
using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using UnityEngine;

public class PlayerDataWindow : OdinMenuEditorWindow
{
    [MenuItem("Windows/ Player data window")]
    private static void OpenWindow()
    {
        GetWindow<PlayerDataWindow>().Show();
    }

    private CreatePlayerData m_createPlayerMovmentData;

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();

        m_createPlayerMovmentData = new CreatePlayerData();

        tree.Add("Create New Player Data", m_createPlayerMovmentData);
        tree.AddAllAssetsAtPath("Palyer data", "Assets/ScriptableObjects/PlayerData/", typeof(PlayerData));

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
