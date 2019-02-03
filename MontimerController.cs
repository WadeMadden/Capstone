using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontimerController : MonoBehaviour
{
    //public Rigidbody mortyRigBod;
    public float mortySpeed;
    public float jumpSpeed;

    public CharacterController mortyController;
    private Vector3 mortyDirection;
    public float gravity;

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

        //enables movement
        mortyDirection = new Vector3(Input.GetAxis("Horizontal") * mortySpeed, mortyDirection.y, Input.GetAxis("Vertical") * mortySpeed);

        Jump();

        mortyDirection.y = mortyDirection.y + (Physics.gravity.y * gravity * Time.deltaTime);
        mortyController.Move(mortyDirection * Time.deltaTime);
    }

    void Jump()
    {
        //jump check
        if (mortyController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                mortyDirection.y = jumpSpeed;
            }
        }
    }
}
