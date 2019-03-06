using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;

    public GameObject pauseMenuUI;

    public TextMeshProUGUI pauseText;

    // Update is called once per frame
    void Update()
    {
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

        Debug.Log("Load File");
        PlayerData data = SaveSystem.LoadPlayer();
        FindObjectOfType<GameManager>().SetGems(data.gems);
        FindObjectOfType<HealthManager>().SetHealth(data.health);

        Vector3 pos;
        pos.x = data.position[0];
        pos.y = data.position[1];
        pos.z = data.position[2];

        FindObjectOfType<MortimerController>().SetMorty(pos);
    }

    public void SaveFile()
    {
        Debug.Log("Save");
        SaveSystem.SavePlayer(FindObjectOfType<MortimerController>().GetMorty(), FindObjectOfType<HealthManager>().GetHealth(), FindObjectOfType<GameManager>().GetGems());
        
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
