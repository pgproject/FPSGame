using Sirenix.OdinInspector;
using UnityEngine;

public abstract class CreateDataBaseClass
{
    protected const string ASSET_EXTENSION = ".asset";
    [SerializeField, Required] protected string m_scriptableObjectName;

    protected abstract void CreateData();
}
