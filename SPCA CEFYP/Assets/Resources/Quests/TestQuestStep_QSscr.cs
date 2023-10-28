using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuestStep_QSscr : QuestSteps_scr
{
    InteractionSystem_scr interactSystem;
    SpriteRenderer sr;
    public GameObject targetInteractable;
    //add variables needed for quest
    //have variable that marks current<> and endgoal criteria

    //if (win boolean)
    //{
    //  FinishQuestStep();
    //}
    void Start()
    {
        sr = targetInteractable.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(interactSystem.hasInteracted == true)
        {
            sr.color = Color.blue;
        }
    }

}
