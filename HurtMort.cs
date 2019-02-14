using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtMort : MonoBehaviour
{
    public int damageGiven = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //check for character collider - may eventually add enemy tags - enemy runs into cactus
        if(other.tag == "Player")
        {
            //knockback
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<HealthManager>().HurtPlayer(damageGiven, hitDirection);
        }
    }
}
