using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;

    public GameObject pauseMenuUI;

    public TextMeshProUGUI pauseText;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        if (paused)
        {
            if (Input.GetButtonDown("Back"))
            {
                Resume();
            }
        }
        if (Input.GetButtonDown("Options"))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        paused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Menu");
    }

    public void LoadFile()
    {
        GameObject[] gems;

       
        PlayerData data = SaveSystem.LoadPlayer();
        //Debug.Log(data.health);
        FindObjectOfType<HealthManager>().SetHealth(data.health);

        Vector3 pos;
        pos.x = data.position[0];
        pos.y = data.position[1];
        pos.z = data.position[2];

        FindObjectOfType<GameManager>().SetGems(0);
        FindObjectOfType<HealthManager>().SetRespawn(pos);
        //gems = GameObject.FindGameObjectsWithTag("disabledGem");
        //Debug.Log(gems.Length);

        //for (int i = 0; i < gems.Length; i++)
        //{
            
        //    gems[i].tag = "enableGem";
        //}

        Resume();
    }

    public void SaveFile()
    {
        Debug.Log(FindObjectOfType<HealthManager>().GetHealth());
        SaveSystem.SavePlayer(FindObjectOfType<HealthManager>().GetRespawn(), FindObjectOfType<HealthManager>().GetHealth());
        
    }

    public void QuitGame()
    {
        FindObjectOfType<GameManager>().SetGems(0);
        paused = false;
        Debug.Log("Quit");
        SceneManager.LoadScene(0);
        //Application.Quit();
    }
}
