using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreateDataBaseClass
{
    protected const string ASSET_EXTENSION = ".asset";
    [SerializeField, Required] protected string m_scriptableObjectName;
    [SerializeField, FolderPath(RequireExistingPath = true), Required] protected string m_scriptableObjectPath;

    public string SciptableObjectPath => m_scriptableObjectPath;

    protected abstract void CreateData();
}
