using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class QuestPoint_scr : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField] QuestInfo_so questInfoForPoint;
    bool playerIsNear = false;
    string questId;
    QuestState_enum currentQuestState;

    void Awake()
    {
        questId = questInfoForPoint.id;
    }

    void OnEnable()
    {
        GameEventsManager_scr.instance.questEvents.onQuestStateChange += QuestStateChange;
        GameEventsManager_scr.instance.interactAction.onSubmitPressed += SubmitPressed;
        
    }

    void OnDisable()
    {
        GameEventsManager_scr.instance.questEvents.onQuestStateChange -= QuestStateChange;
        GameEventsManager_scr.instance.interactAction.onSubmitPressed -= SubmitPressed;
    }

    void QuestStateChange(Quest_scr quest)
    {
        if (quest.info.id.Equals(questId))
        {
            currentQuestState = quest.state;
            Debug.Log("Quest with id: " + questId + "updated to state: " + currentQuestState);
        }
    }

    void SubmitPressed()
    {
        if (!playerIsNear)
        {
            return;
        }
        GameEventsManager_scr.instance.questEvents.StartQuest(questId);
        GameEventsManager_scr.instance.questEvents.AdvanceQuest(questId);
        GameEventsManager_scr.instance.questEvents.FinishQuest(questId);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController_scr>())
        {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController_scr>())
        {
            playerIsNear = false;
        }
    }
}
