using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        Time.timeScale = 1;

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
            PlayerData data = SaveSystem.LoadPlayer();
            //Debug.Log(data.health);
            //FindObjectOfType<HealthManager>().SetHealth(data.health);

            Vector3 pos;
            pos.x = data.position[0];
            pos.y = data.position[1];
            pos.z = data.position[2];

            //FindObjectOfType<GameManager>().SetGems(0);
            //FindObjectOfType<HealthManager>().SetRespawn(pos);
            //gems = GameObject.FindGameObjectsWithTag("disabledGem");
            //Debug.Log(gems.Length);

            //for (int i = 0; i < gems.Length; i++)
            //{

            //    gems[i].tag = "enableGem";
            //}
            //FindObjectOfType<GameManager>().SetGems(0);
            SceneManager.LoadScene(data.actScene);

            //Resume();
        
    }
}
