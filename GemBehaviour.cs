using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
    //allows for turning animation on or off
    public bool gemAnimated;

    //allows for turning rotation on or off
    public bool rotating;

    public Vector3 rotateAngle;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gemAnimated)
        {
            if (rotating)
            {
                transform.Rotate(rotateAngle * rotateSpeed * Time.deltaTime);
            }
        }
    }
}
