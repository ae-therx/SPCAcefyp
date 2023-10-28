using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager_scr : MonoBehaviour
{
    Dictionary<string, Quest_scr> questMap;

    void Awake()
    {
        questMap = CreateQuestMap();
    }

    void OnEnable()
    {
        GameEventsManager_scr.instance.questEvents.onStartQuest += StartQuest;
        GameEventsManager_scr.instance.questEvents.onAdvanceQuest += AdvanceQuest;
        GameEventsManager_scr.instance.questEvents.onFinishQuest += FinishQuest;
    }

    void OnDisable()
    {
        GameEventsManager_scr.instance.questEvents.onStartQuest -= StartQuest;
        GameEventsManager_scr.instance.questEvents.onAdvanceQuest -= AdvanceQuest;
        GameEventsManager_scr.instance.questEvents.onFinishQuest -= FinishQuest;
    }

    void Start()
    {
        foreach ( Quest_scr quest in questMap.Values)
        {
            GameEventsManager_scr.instance.questEvents.QuestStateChange(quest);
        }
    }

    void StartQuest(string id)
    {
        Debug.Log("Start Quest:" + id);
    }

    void AdvanceQuest(string id)
    {
        Debug.Log("Advance Quest:" + id);
    }

    void FinishQuest(string id)
    {
        Debug.Log("Finish Quest:" + id);
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
