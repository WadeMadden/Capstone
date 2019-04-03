using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;



public class HealthManager : MonoBehaviour
{
    public int health;
    public int maximumHealth;
    public TextMeshProUGUI healthUI;

    public MortimerController morty;

    public float invincibilityFrames;
    private float invincibilityCounter;

    public Renderer bodyRenderer;
    public Renderer clothesRenderer;
    public Renderer weaponRenderer;
    public Renderer shieldRenderer;

    private float flashCounter;
    public float flashFrames = 0.1f;

    public bool isRespawning;
    private Vector3 respawnPoint;
    private Quaternion respawnRotation;
    public float respawnTimer;

    public GameObject deathEffect;

    public Image blackScreen;
    private bool isFadeToBlack;
    private bool isFadeFromBlack;
    public float fadeSpeed;
    public float waitForFade;

    // Start is called before the first frame update
    void Start()
    {
        health = maximumHealth;
        healthUI.text = health.ToString();
        //morty = FindObjectOfType<MortimerController>();
        respawnPoint = morty.transform.position;
        respawnRotation = morty.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
        //countdown for invincibility
        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
                bodyRenderer.enabled = !bodyRenderer.enabled;
                clothesRenderer.enabled = !clothesRenderer.enabled;
                shieldRenderer.enabled = !shieldRenderer.enabled;
                weaponRenderer.enabled = !weaponRenderer.enabled;
                flashCounter = flashFrames;
            }

            if(invincibilityCounter <= 0)
            {
                
                bodyRenderer.enabled = true;
                clothesRenderer.enabled = true;
                shieldRenderer.enabled = true;
                weaponRenderer.enabled = true;
            }
        }

        if (isFadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 1f)
            {
                isFadeToBlack = false;
            }
        }

        if (isFadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 0f)
            {
                isFadeFromBlack = false;
            }
        }
    }

    public void HurtPlayer(int damage, Vector3 direction)
    {
        
        if (invincibilityCounter <= 0)
        {
            health -= damage;
            if (health <= 0)
            {
                healthUI.text = health.ToString();
                
                Respawn();

            }
            else
            {

                healthUI.text = health.ToString();
                

                morty.KnockBack(direction);
                invincibilityCounter = invincibilityFrames;


                //turns off mesh when player is hit
                bodyRenderer.enabled = false;
                clothesRenderer.enabled = false;
                shieldRenderer.enabled = false;
                weaponRenderer.enabled = false;

                flashCounter = flashFrames;
            }
        }
        
    }

    public void Respawn()
    {

        healthUI.text = health.ToString();
        if (!isRespawning)
        {
            StartCoroutine("RespawnCo");
        }
    }

    public IEnumerator RespawnCo()
    {
        isRespawning = true;

        morty.gameObject.SetActive(false);

        Instantiate(deathEffect, morty.transform.position, morty.transform.rotation);
        if (morty.sprint)
        {
            morty.sprint = false;
            morty.mortySpeed /= 1.5f;
        }


        yield return new WaitForSeconds(respawnTimer);

        isFadeToBlack = true;

        yield return new WaitForSeconds(waitForFade);

        isFadeToBlack = false;

        isFadeFromBlack = true;

        isRespawning = false;

        morty.gameObject.SetActive(true);
        morty.transform.position = respawnPoint;
        morty.transform.rotation = respawnRotation;
        health = maximumHealth;
        healthUI.text = health.ToString();

        invincibilityCounter = invincibilityFrames;


        //turns off mesh when player is hit
        bodyRenderer.enabled = false;
        clothesRenderer.enabled = false;
        shieldRenderer.enabled = false;
        weaponRenderer.enabled = false;

        flashCounter = flashFrames;
    }

    public Vector3 GetRespawn()
    {
        return respawnPoint;
    }

    public void SetRespawn(Vector3 resp)
    {
        respawnPoint = resp;
        Respawn();
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int healthTotal)
    {
        health = healthTotal;
        healthUI.text = health.ToString();
    }
    public void HealPlayer(int healAmount)
    {
       
        if (health >= maximumHealth)
        {
            healthUI.text = health.ToString();
            health = maximumHealth;
        }
        else
        {
            health += healAmount;
            healthUI.text = health.ToString();
        }
    }

    public void killPlayer()
    {
        Vector3 def = new Vector3();
        HurtPlayer(health, def);
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
}
