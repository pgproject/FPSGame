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
    [MenuItem("Windows/ editor window test")]

    private static void OpenWindow()
    {
        GetWindow<EditorWindowTest>().Show();
    }

    [ValueDropdown(nameof(Components))] public Type[] NewItemObject;
    private IEnumerable<Type> Components()
    {
        return from assembly in AppDomain.CurrentDomain.GetAssemblies()
               from type in assembly.GetTypes()
               where typeof(Component).IsAssignableFrom(type)
               select type;
    }
}
