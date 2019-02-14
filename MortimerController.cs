using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MortimerController : MonoBehaviour
{
    //public Rigidbody mortyRigBod;
    public float mortySpeed;
    public float jumpSpeed;

    public CharacterController mortyController;
    private Vector3 mortyDirection;
    public float gravity;

    //bool for checking if character can double jump
    private bool dblJump;
    private bool sprint;
    private bool backwards;
    private bool walkLeft;
    private bool walkRight;
    private bool forwards;
    private float angle;

    private bool defend;

    private bool roll;

    public Animator animator;

    public Transform pivot;
    public float rotateSpeed;
    public GameObject playerModel;


    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    public bool wasHurt;
    // Start is called before the first frame update
    void Start()
    {
        //mortyRigBod = GetComponent<Rigidbody>();

        mortyController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.paused)
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


            if (knockBackCounter <= 0)
            {

                wasHurt = false;

                float yStored = mortyDirection.y;
                //enables movement
                //applies whatever direction the character is facing to controls
                mortyDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));

                //normalizing speed
                mortyDirection = mortyDirection.normalized * mortySpeed;

                //fixes jump by using stored y value before normalizing
                mortyDirection.y = yStored;

                Jump();
                Sprint();
                Roll();

                //May implement check movement in the future but currently is unneeded
                //CheckMovement();
                forwards = true;
            }
            else
            {
                /********************************************
                 * */
                

                wasHurt = true;
                knockBackCounter -= Time.deltaTime;
                //fixed bug where player would get stuck in sprint mode
                if (sprint)
                {
                    mortySpeed /= 1.5f;
                    sprint = false;
                }
            }

            mortyDirection.y = mortyDirection.y + (Physics.gravity.y * gravity * Time.deltaTime);
            mortyController.Move(mortyDirection * Time.deltaTime);



            //move in different directions - camera facing angle
            if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f))
            {

                transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);

                Quaternion newRotate = Quaternion.LookRotation(new Vector3(mortyDirection.x, 0f, mortyDirection.z));
                playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotate, rotateSpeed * Time.deltaTime);
            }



            Animations();

        }
    }

    void Sprint()
    {
        if (Input.GetButtonDown("Sprint") && (backwards == false && walkRight == false && walkLeft == false))
        {
            if(sprint == false)
            {
                mortySpeed *= 1.5f;
            }
            sprint = true;
            
        }
        if (Input.GetButtonUp("Sprint") || (backwards == true || walkRight == true || walkLeft == true))
        {
            if (sprint)
            {
                mortySpeed /= 1.5f;
            }
            sprint = false;
        }
    }

    void Roll()
    {
        if(!roll && Input.GetButtonDown("Roll") && mortyController.isGrounded )
        {
            roll = true;

        }        
        else if(Input.GetButtonUp("Roll") || !mortyController.isGrounded || roll)
        {
            if (roll)
            {
                roll = false;
                
            }
        }
        
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
                animator.SetBool("dblJump", dblJump);
            }
        }
        //double jump check
        if (!mortyController.isGrounded && dblJump)
        {
            if (Input.GetButtonDown("Jump"))
            {
                mortyDirection.y = jumpSpeed;
                dblJump = false;
                animator.SetBool("dblJump", dblJump);
            }

        }
    }

    void CheckMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        if (Input.GetButtonUp("Defend") || defend == false)
        {
            defend = false;
            forwards = true;
            backwards = false;
            walkLeft = false;
            walkRight = false;

        }
        if (Input.GetButtonDown("Defend") && (angle < -55f && angle > -125f))
        {
            defend = true;
            backwards = true;
            walkLeft = false;
            walkRight = false;
            forwards = false;
        }
        if (Input.GetButtonDown("Defend") && ((angle > -55f && angle < 55f) || mortySpeed != 0.0f))
        {
            defend = true;
            walkRight = true;
            walkLeft = false;
            forwards = false;
            backwards = false;
        }
        if (Input.GetButtonDown("Defend") && ((angle <= 180f && angle > 125f) || (angle >= -180f && angle < -125f)))
        {
            defend = true;
            walkLeft = true;
            walkRight = false;
            forwards = false;
            backwards = false;
        }
        if (Input.GetButtonDown("Defend") && ((angle > 55f && angle < 125f) || mortySpeed == 0.0f))
        {
            defend = true;
            forwards = true;
            backwards = false;
            walkLeft = false;
            walkRight = false;
        }
        //moving backwards
        
    }

    public void KnockBack(Vector3 direction)
    {
        knockBackCounter = knockBackTime;
        mortyDirection = direction * knockBackForce;
        mortyDirection.y = knockBackForce;
    }

    public void Animations()
    {
        animator.SetBool("wasHurt", wasHurt);
        animator.SetBool("roll", roll);
        animator.SetBool("defend", defend);
        animator.SetFloat("angle", angle);
        animator.SetBool("walkRight", walkRight);
        animator.SetBool("walkLeft", walkLeft);
        animator.SetBool("backwards", backwards);
        animator.SetBool("forwards", forwards);
        animator.SetBool("sprint", sprint);
        animator.SetBool("isGrounded", mortyController.isGrounded);
        animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + (Mathf.Abs(Input.GetAxis("Horizontal")))));
        
    }
}
