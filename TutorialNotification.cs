using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialNotification : MonoBehaviour
{
    public GameObject tutorialMessage;
    // Start is called before the first frame update
    void Start()
    {
        tutorialMessage.SetActive(false);
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
            tutorialMessage.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            tutorialMessage.SetActive(false);
        }

    }
}
