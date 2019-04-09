using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelColl : MonoBehaviour
{
    private GameObject findGemsMessage;
    private GameObject findGemsNumber;
    // Start is called before the first frame update
    void Start()
    {
        findGemsMessage = GameObject.FindGameObjectWithTag("FindGemsUI");
        findGemsMessage.gameObject.SetActive(false);
        findGemsNumber = GameObject.FindGameObjectWithTag("FindGemsNumber");
        findGemsNumber.gameObject.SetActive(false);
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
            if (GameObject.FindGameObjectsWithTag("enableGem").Length == 0)
            {
                FindObjectOfType<GameManager>().SetGems(0);
                SceneManager.LoadScene(0);
            }
            //if (FindObjectOfType<GameManager>().gemLevelComplete == FindObjectOfType<GameManager>().GetGems())
            //{
            //    FindObjectOfType<GameManager>().SetGems(0);
            //    SceneManager.LoadScene(0);
            //}
            else
            {
                findGemsMessage.gameObject.SetActive(true);
                findGemsNumber.gameObject.SetActive(true);
                Debug.Log("Find more gems");
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            findGemsMessage.gameObject.SetActive(false);
            findGemsNumber.gameObject.SetActive(false);
        }

    }
}
