using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealMort : MonoBehaviour
{
    public int healAmount = 1;
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
        if (other.tag == "Player")
        {
            Console.WriteLine("Healing");
            FindObjectOfType<HealthManager>().HealPlayer(healAmount);
            Destroy(gameObject);
        }
    }
}
