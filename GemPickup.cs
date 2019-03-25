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
        if(gemComplete.tag == "enableGem")
        {
            gemComplete.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            FindObjectOfType<AudioManager>().GemSound();
            FindObjectOfType<GameManager>().AddGem(gemVal);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            
            gemComplete.SetActive(false);
            gemComplete.tag = "disabledGem";
            
            //Destroy(gameObject);
            //Destroy(halo);
        }
    }
}
