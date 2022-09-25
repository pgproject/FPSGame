using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EditorWindowTest : OdinEditorWindow
{
    //[ValueDropdown("Values", AppendNextDrawer = true), BoxGroup("settings"), SerializeField] public A m_playerData;
    [MenuItem("Windows/ editor window test")]

    private static void OpenWindow()
    {
        GetWindow<EditorWindowTest>().Show();
    }


    //private IEnumerable<A> Values => TypeCache
    //    .GetTypesDerivedFrom<A>()
    //    .Select(type => (A)Activator.CreateInstance(type));
        
}
