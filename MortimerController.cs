using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortimerController : MonoBehaviour
{
    //public Rigidbody mortyRigBod;
    public float mortySpeed;
    public float jumpSpeed;

    public CharacterController mortyController;
    private Vector3 mortyDirection;
    public float gravity;

    //bool for checking if character can double jump
    public bool dblJump;

    // Start is called before the first frame update
    void Start()
    {
        //mortyRigBod = GetComponent<Rigidbody>();

        mortyController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Rigid body made character too floaty
        mortyRigBod.velocity = new Vector3(Input.GetAxis("Horizontal") * mortySpeed, mortyRigBod.velocity.y, Input.GetAxis("Vertical") * mortySpeed);
        
        if (Input.GetButtonDown("Jump"))
        {
            mortyRigBod.velocity = new Vector3(mortyRigBod.velocity.x, jumpSpeed, mortyRigBod.velocity.z);
        }*/

        //Character controller works better. Character sticks to the ground

        //this mode of movement does not allow player to move in whichever way the camera is facing. Needs to be changed
        //mortyDirection = new Vector3(Input.GetAxis("Horizontal") * mortySpeed, mortyDirection.y, Input.GetAxis("Vertical") * mortySpeed);


        float yStored = mortyDirection.y;
        //enables movement
        //applies whatever direction the character is facing to controls
        mortyDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));

        //normalizing speed
        mortyDirection = mortyDirection.normalized * mortySpeed;

        //fixes jump by using stored y value before normalizing
        mortyDirection.y = yStored;

        Jump();

        mortyDirection.y = mortyDirection.y + (Physics.gravity.y * gravity * Time.deltaTime);
        mortyController.Move(mortyDirection * Time.deltaTime);
    }

    void Jump()
    {
        //jump check
        if (mortyController.isGrounded)
        {
            mortyDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                mortyDirection.y = jumpSpeed;
                dblJump = true;
            }
        }
        //double jump check
        if (!mortyController.isGrounded && dblJump)
        {
            if (Input.GetButtonDown("Jump"))
            {
                mortyDirection.y = jumpSpeed;
                dblJump = false;
            }

        }
    }
}
