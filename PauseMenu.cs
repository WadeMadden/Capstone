using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
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
        Debug.Log("Load");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
    }
}
