using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{   
    //CharacterSpeed you can do it manually in unity too ,dont change this 
    [SerializeField] private float characterSpeed;
    [SerializeField] private float characterJumpSpeed;
    //player RigidBody
    private Rigidbody2D playerCharacterRgb;
    //organizing the code 
    private Vector2 move = new Vector2(1, 0);
    private Vector2 jump = new Vector2(0, 1);
    void Start()
    {
        //set the rigidbody to our character
        playerCharacterRgb = gameObject.GetComponent<Rigidbody2D>();
    }
    // we use fixedupdate instead of update because its not as heavy as update and its better for our game 
    void FixedUpdate()
    {
        Movements();
    }

    void Movements()
   {
       //moving right and left : D right and A left
       if (Input.GetKey(KeyCode.D))
        {
            playerCharacterRgb.velocity = move * characterSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerCharacterRgb.velocity = (-move)  * characterSpeed;
        }
        if (Input.GetButtonDown("Jump"))
       {
           
           playerCharacterRgb.AddForce(jump*characterJumpSpeed);
          
       }
       
   }
    
}
