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
    // Start is called before the first frame update
    void Start()
    {
        //checking if user wants camera presets
        if (!useOffset)
        {
            offset = targ.position - transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //x position of controller and rotate target
        float horiz = Input.GetAxis("ControllerHoriz") * rotationSpeed;
        targ.Rotate(0, horiz, 0);

        float vert = Input.GetAxis("ControllerVert") * rotationSpeed;
        targ.Rotate(vert, 0f, 0f);

        //change camera based on rotatoin of target and offset
        float yAng = targ.eulerAngles.y;
        float xAng = targ.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(xAng, yAng, 0f);
        transform.position = targ.position - (rotation * offset);

        //transform.position = targ.position - offset;
        transform.LookAt(targ);
    }
}
