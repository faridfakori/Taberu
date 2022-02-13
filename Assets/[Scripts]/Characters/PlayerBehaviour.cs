using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player Movement")]
    public float horizontalForce;
    public float verticalForce;
    public float dashForce;

    [Header("Ground Detection")]
    public Transform groundCheck1;
    public Transform groundCheck2;
    public float groundRadius;
    public LayerMask groundLayerMask;
    public bool isGrounded;
    public bool slope;
    public AudioSource audio;

    //[Header("Animation Properties")] 
    private Animator animator;
    private SpriteRenderer spriteRender;
    private Rigidbody2D rigidBody2D;    
    
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

   
    void FixedUpdate()
    {        
        Move();
        SpecialMove();
    }

    private void Move()
    {      
        //isGrounded = Physics2D.Linecast(groundCheck1.position, groundCheck2.position, groundLayerMask); 
        isGrounded = Physics2D.OverlapCircle(groundCheck1.position, groundRadius, groundLayerMask);
        //slope = Physics2D.Linecast(transform.position, groundCheck2.position, groundLayerMask);      

        //if (slope) { transform.localRotation = Quaternion.Euler(0, 0, 27); }
        //else { transform.localRotation = Quaternion.Euler(0, 0, 0); }
        

        if (isGrounded)
        {           
            float bounce = Input.GetAxisRaw("Horizontal"); //GetAxis sólo todos los valores entre -1 y 1. Raw, sólo -1,0 y 1.
            float jump = Input.GetAxisRaw("Jump")*500; //JumpForce = 500
            float roll = Input.GetAxisRaw("Roll");  

            if (bounce != 0 && roll == 0)
            {
                bounce = Flip(bounce);
                animator.SetInteger("AnimationState", 1); //Bouncing State
            }
            else if (bounce == 0 && jump == 0)
            {
                animator.SetInteger("AnimationState", 0); //Idle State
            }

            if (jump > 0 && roll == 0)
            {
                audio.Play();
                animator.SetInteger("AnimationState", 2); //Jump State
            } 
            else if (bounce == 0 && roll < 0)
            {
                //animator.SetInteger("AnimationState", 3); //Rolling State
            }
            if (roll == 0)
            {
                //Vector2 move = new Vector2(bounce * horizontalForce, jump * verticalForce);
                Vector2 move = new Vector2(bounce * horizontalForce, (Mathf.Abs(bounce) * verticalForce + jump));
                rigidBody2D.AddForce(move);
            }
            
        }
    }

    private void SpecialMove()
    {
        Vector2 move = new Vector2(1, 0);
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            Debug.Log("S pressed");
            rigidBody2D.AddForce(move * dashForce);
            animator.SetInteger("AnimationState", 3); //DashState
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            Debug.Log("S pressed");
            rigidBody2D.AddForce((-move) * dashForce); 
            animator.SetInteger("AnimationState", 3); //Bouncing State
        }
    }

    private float Flip(float x)
    {
        x = (x > 0) ? 1 : -1;  //Ternary operator
        transform.localScale = new Vector3(x, 1.0f);        
        return x;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundCheck1.position, groundRadius);
        Gizmos.DrawLine(transform.position, groundCheck2.position);
        //Gizmos.DrawLine(groundCheck1.position, groundCheck2.position);
    }
}
