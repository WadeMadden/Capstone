using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


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
    // Start is called before the first frame update
    void Start()
    {
        health = maximumHealth;
        healthUI.text = health.ToString();
        morty = FindObjectOfType<MortimerController>();
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
    }

    public void HurtPlayer(int damage, Vector3 direction)
    {
        if (invincibilityCounter <= 0)
        {
            health -= damage;
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

    public void HealPlayer(int healAmount)
    {
        health += healAmount;

        if (health > maximumHealth)
        {
            health = maximumHealth;
        }
    }
}
