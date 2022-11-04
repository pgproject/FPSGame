using Sirenix.OdinInspector.Editor;
using UnityEditor;
using Sirenix.Utilities.Editor;
using UnityEngine;

public class PlayerDataWindow : OdinMenuEditorWindow
{
    [MenuItem("Windows/ Player data window")]
    private static void OpenWindow()
    {
        GetWindow<PlayerDataWindow>().Show();
    }
    private const string m_pathForItems = "Assets/ScriptableObjects/Items/";


    private CreatePlayerData m_createPlayerMovmentData;

    private Items<Weapon> m_weapons;
    private Items<DefenseItem> m_defenseItem;
    private Items<Obstacle> m_obstacles;
    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();

        m_createPlayerMovmentData = new CreatePlayerData();

        m_weapons = new Items<Weapon>();
        m_defenseItem = new Items<DefenseItem>();
        m_obstacles = new Items<Obstacle>();

        tree.Add("Create New Player Data", m_createPlayerMovmentData);

        tree.Add("Create weapon", m_weapons);
        tree.Add("Create defense item", m_defenseItem);
        tree.Add("Create obstacle", m_obstacles);

        tree.AddAllAssetsAtPath("Palyer data", "Assets/ScriptableObjects/PlayerData/", typeof(PlayerData));

        tree.AddAllAssetsAtPath("Weapons", m_pathForItems + typeof(Weapon).Name, typeof(Weapon));
        tree.AddAllAssetsAtPath("Defense Items", m_pathForItems + typeof(DefenseItem).Name, typeof(DefenseItem));
        tree.AddAllAssetsAtPath("Obstalces", m_pathForItems + typeof(Obstacle).Name, typeof(Obstacle));

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
        if (this.MenuTree != null)
        {
            OdinMenuTreeSelection odinMenuSelectied = this.MenuTree.Selection;

            SirenixEditorGUI.BeginHorizontalToolbar();
            {
                GUILayout.FlexibleSpace();

                if (SirenixEditorGUI.ToolbarButton("Delete current"))
                {
                    ScriptableObject asset = odinMenuSelectied.SelectedValue as ScriptableObject;

                    string pathToAsset = AssetDatabase.GetAssetPath(asset);
                    AssetDatabase.DeleteAsset(pathToAsset);
                    AssetDatabase.SaveAssets();
                }
            }
            SirenixEditorGUI.EndHorizontalToolbar();
        }
    }

}
