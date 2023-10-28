using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfo_SO", menuName = "ScriptableObjects/QuestInfo_ScriptableObject" , order = 1)]
public class QuestInfo_so : ScriptableObject
{
    [field:SerializeField] public string id { get; private set; }

    [Header("General")]
    public string displayName;

    [Header("Requirements")]
    public QuestInfo_so[] questPrerequisites;

    [Header("Steps")]
    public GameObject[] questStepPrefabs;

    //[Header("Rewards")]
    //public int <>

    void OnValidate()
    {
        #if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
            //id = name of scriptable object asset
    }
}
