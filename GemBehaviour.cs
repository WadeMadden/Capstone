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

    //floating on or off
    public bool floating;
    public float hoverSpeed;
    private bool movingUp;
    public float hoverRate;
    private float hoverTimer;

    //scaling larger and smaller
    public Vector3 cycleStart;
    public Vector3 cycleEnd;

    public bool cycling;
    private bool scaleUp;
    public float cyclecSpeed;
    public float cycleRate;
    private float cycleTimer;

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

        if (floating)
        {
            hoverTimer += Time.deltaTime;
            Vector3 dir = new Vector3(0.0f, 0.0f, hoverSpeed);
            transform.Translate(dir);

            if(movingUp && hoverTimer >= hoverRate)
            {
                movingUp = false;
                hoverTimer = 0;
                hoverSpeed = -hoverSpeed;
            }
            else if(!movingUp && hoverTimer >= hoverRate)
            {
                movingUp = true;
                hoverTimer = 0;
                hoverSpeed = +hoverSpeed;
            }
        }
        if (cycling)
        {
            cycleTimer += Time.deltaTime;

            if (scaleUp)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, cycleEnd, cyclecSpeed * Time.deltaTime);
            }
            else if (!scaleUp)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, cycleStart, cyclecSpeed * Time.deltaTime);
            }

            if(cycleTimer >= cycleRate)
            {
                if (scaleUp)
                {
                    scaleUp = false;
                }
                else if (!scaleUp)
                {
                    scaleUp = true;
                }
                cycleTimer = 0;
            }
        }
    }
}
