using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    Dictionary<string, Quest_scr> questMap;

    void Awake()
    {
        questMap = CreateQuestMap();
    }

    Dictionary<string, Quest_scr> CreateQuestMap()
    {
        
        QuestInfo_so[] allQuests = Resources.LoadAll<QuestInfo_so>("Quests");
        //loads all QuestInfo_so Scriptable Objects under Assets/Resources/Quests folder

        Dictionary<string, Quest_scr> idToQuestMap = new Dictionary<string, Quest_scr>();
        foreach(QuestInfo_so questInfo in allQuests)
        {
            if (idToQuestMap.ContainsKey(questInfo.id))
            {
                Debug.LogWarning("Duplicate ID found when creating quest map: " + questInfo.id);
            }
            idToQuestMap.Add(questInfo.id, new Quest_scr(questInfo));
        }
        return idToQuestMap;
    }

    Quest_scr GetQuestById(string id)
        //uses a string id and returns a quest
    {
        Quest_scr quest = questMap[id];
        if(quest == null)
        {
            Debug.LogError("ID not found in the Quest Map: " + id);
        }
        return quest;
    }

}
