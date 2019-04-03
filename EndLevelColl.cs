using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelColl : MonoBehaviour
{
    private GameObject findGemsMessage;
    // Start is called before the first frame update
    void Start()
    {
        findGemsMessage = GameObject.FindGameObjectWithTag("FindGemsUI");
        findGemsMessage.gameObject.SetActive(false);
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
            if (FindObjectOfType<GameManager>().gemLevelComplete == FindObjectOfType<GameManager>().GetGems())
            {
                FindObjectOfType<GameManager>().SetGems(0);
                SceneManager.LoadScene(0);
            }
            else
            {
                findGemsMessage.gameObject.SetActive(true);
                Debug.Log("Find more gems");
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            findGemsMessage.gameObject.SetActive(false);
        }

    }
}
