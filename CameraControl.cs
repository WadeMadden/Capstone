using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //target for the camera to look at
    public Transform targ;
    public Vector3 offset;
    public bool useOffset;
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
        transform.position = targ.position - offset;
        transform.LookAt(targ);
    }
}
