using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickup : MonoBehaviour
{
    public int gemVal;
    public GameObject pickupEffect;
    public Light halo;
    public GameObject gemComplete;
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
        if(other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddGem(gemVal);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            gemComplete.SetActive(false);
            
            //Destroy(gameObject);
            //Destroy(halo);
        }
    }
}
