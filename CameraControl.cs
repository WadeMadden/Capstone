using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //target for the camera to look at
    public Transform targ;
    public Vector3 offset;
    public bool useOffset;
    public float rotationSpeed;


    //child object of player to act as pivot point for camera
    public Transform pivot;

    //camera bounds
    public float upperCameraBound;
    public float lowerCameraBound;

    public bool invertCameraY;
    public bool invertCameraX;
    // Start is called before the first frame update
    void Start()
    {
        //make cursor disappear
        Cursor.lockState = CursorLockMode.Locked;

        //checking if user wants camera presets
        if (!useOffset)
        {
            offset = targ.position - transform.position;
        }

        //move pivot to character position
        pivot.transform.position = targ.transform.position;
        //Rework this part to make camera move around player
        //pivot.transform.parent = targ.transform;

        //Don't want as a child here
        pivot.transform.parent = null;
        
    }

    // Update is called once per frame
    //LateUpdate so that character movement is processed before camera moves
    void LateUpdate()
    {
        //pivot will move with player
        pivot.transform.position = targ.transform.position;

        //x position of controller and rotate target
        float horiz = Input.GetAxis("ControllerHoriz") * rotationSpeed;
        

        //y position of controller and rotate pivot

        float vert = Input.GetAxis("ControllerVert") * rotationSpeed;

        InvertX(horiz);
        InvertY(vert);
        

        //change camera based on rotatoin of target and offset
        float yAng = pivot.eulerAngles.y;
        float xAng = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(xAng, yAng, 0f);
        transform.position = targ.position - (rotation * offset);

        //transform.position = targ.position - offset;

        SetBounds(yAng);

        transform.LookAt(targ);
    }

    //Makes it so camera cannot move above or below a certain value
    public void SetBounds(float yAng)
    {
        if(pivot.rotation.eulerAngles.x > upperCameraBound && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(upperCameraBound, yAng, 0f);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + lowerCameraBound)
        {
            pivot.rotation = Quaternion.Euler(360f + lowerCameraBound, yAng, 0f);
        }

        if(transform.position.y < targ.position.y)
        {
            transform.position = new Vector3(transform.position.x, targ.position.y - .5f, transform.position.z);
        }
    }

    //checks if player wants to invert camera
    public void InvertY(float vert)
    {
        if (invertCameraY)
        {
            pivot.Rotate(vert, 0f, 0f);
        }
        else
        {
            pivot.Rotate(-vert, 0f, 0f);
        }
    }

    public void InvertX(float horiz)
    {
        if (invertCameraX)
        {
            pivot.Rotate(0f, horiz, 0f);
        }
        else
        {
            pivot.Rotate(0f, -horiz, 0f);
        }
    }
}
