using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_scr : MonoBehaviour
{
    InteractableObject_scr nearestInteractableObject;

    //local variables
    Rigidbody2D rb;
    Collider2D playerCollider;

    [SerializeField] public bool isInteracting = false;

    [Header("Interact Parameters")]
    public float interactableDistance;

    [Header("Ground Check Parameters")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.21f;
    public LayerMask whatCanBeSteppedOn;
    bool isGrounded;

    [Header("Movement Parameters")]
    public float moveSpeed;
    public float jumpHeight;

    /*[Header("Sound Effects")]
    AudioSource audioSource;
    public AudioClip nameSound;
    */

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isInteracting);
        //MOVEMENT RELATED
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatCanBeSteppedOn);
        //checking if grounded

        Movement_Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("Jump"))
        {
            Movement_Jump();
        }

        //INTERACTION RELATED
        Debug.Log(isInteracting + " isInteracting");

        if (Input.GetKeyDown(KeyCode.E))
        {

        }



    }

    void Movement_Jump()
    {
        if (!isGrounded) return;
        rb.velocity += new Vector2(0, jumpHeight);
    }

    void Movement_Move(float dir)
    {
        if (dir > 0)
            //right
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (dir < 0)
            //left
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
            //not moving
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }


}
