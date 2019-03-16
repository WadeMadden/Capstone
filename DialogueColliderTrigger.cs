using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueColliderTrigger : MonoBehaviour
{
    public GameObject triangleCyl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Triangle"))
        {
            triangleCyl.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triangleCyl.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triangleCyl.SetActive(false);
        }

    }
}
