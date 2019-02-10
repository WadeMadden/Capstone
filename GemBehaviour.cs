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
            Vector3 dir = new Vector3(0f, 0f, hoverSpeed);
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
    }
}
