using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_scr
{
    // static info
    public QuestInfo_so info;

    // state info
    public QuestState_enum state;
    private int currentQuestStepIndex;


    public Quest_scr(QuestInfo_so questInfo)
    {
        this.info = questInfo;
        this.state = QuestState_enum.REQUIREMENTS_NOT_MET;
        this.currentQuestStepIndex = 0;

    }

    public Quest_scr(QuestInfo_so questInfo, QuestState_enum questState, int currentQuestStepIndex)
    {
        this.info = questInfo;
        this.state = questState;
        this.currentQuestStepIndex = currentQuestStepIndex;


        // if the quest step states and prefabs are different lengths,
        // something has changed during development and the saved data is out of sync.
        
    }

    public void MoveToNextStep()
    {
        currentQuestStepIndex++;
    }

    public bool CurrentStepExists()
    {
        return (currentQuestStepIndex < info.questStepPrefabs.Length);
    }

    public void InstantiateCurrentQuestStep(Transform parentTransform)
    {
        GameObject questStepPrefab = GetCurrentQuestStepPrefab();
        if (questStepPrefab != null)
        {
            QuestSteps_scr questStep = Object.Instantiate<GameObject>(questStepPrefab, parentTransform)
                .GetComponent<QuestSteps_scr>();
            
        }
    }

    private GameObject GetCurrentQuestStepPrefab()
    {
        GameObject questStepPrefab = null;
        if (CurrentStepExists())
        {
            questStepPrefab = info.questStepPrefabs[currentQuestStepIndex];
        }
        else
        {
            Debug.LogWarning("Tried to get quest step prefab, but stepIndex was out of range indicating that "
                + "there's no current step: QuestId=" + info.id + ", stepIndex=" + currentQuestStepIndex);
        }
        return questStepPrefab;
    }


}
