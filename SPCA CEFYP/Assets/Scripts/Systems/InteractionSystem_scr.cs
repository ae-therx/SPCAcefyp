using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem_scr : MonoBehaviour
{
    [Header("Interaction Parameters")]
    public Transform interactDetectionPoint;
    public LayerMask whatIsInteractable;
    const float interactDetectionRadius = 0.2f;

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
            }
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectInteractableObjects()
    {
        return Physics2D.OverlapCircle(interactDetectionPoint.transform.position, interactDetectionRadius, whatIsInteractable);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(interactDetectionPoint.transform.position, interactDetectionRadius);
    }
}
