using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InteractionSystem_scr : MonoBehaviour
{
    [Header("Interaction Parameters")]
    public Transform interactDetectionPoint;
    public LayerMask whatIsInteractable;
    const float interactDetectionRadius = 0.4f;

    [SerializeField] public bool hasInteracted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectInteractableObjects())
        {
            if (InteractInput())
            {
                Debug.Log("Interact!");
                hasInteracted = true;
                onSubmitPressed();
            }
            else
            {
                hasInteracted = false;
            }
        }
    }

    public event Action onSubmitPressed;

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    public bool DetectInteractableObjects()
    {
        return Physics2D.OverlapCircle(interactDetectionPoint.transform.position, interactDetectionRadius, whatIsInteractable);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(interactDetectionPoint.transform.position, interactDetectionRadius);
    }
}
