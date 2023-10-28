using System;
using UnityEngine;

public class GameEventsManager_scr : MonoBehaviour
{
    public static GameEventsManager_scr instance { get; private set; }

    public QuestEvents_scr questEvents;
    public InteractionSystem_scr interactAction;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }
        instance = this;

        questEvents = new QuestEvents_scr();
    }


}
