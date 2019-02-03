using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontimerController : MonoBehaviour
{
    public Rigidbody mortyRigBod;
    public float mortySpeed;
    public float jumpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        mortyRigBod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //enables mobility
        mortyRigBod.velocity = new Vector3(Input.GetAxis("Horizontal") * mortySpeed, mortyRigBod.velocity.y, Input.GetAxis("Vertical") * mortySpeed);
        //jumping control
        if (Input.GetButtonDown("Jump"))
        {
            mortyRigBod.velocity = new Vector3(mortyRigBod.velocity.x, jumpSpeed, mortyRigBod.velocity.z);
        }
    }
}
