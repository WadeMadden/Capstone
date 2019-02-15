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
        
    }

    public void HurtPlayer(int damage, Vector3 direction)
    {
        
        health -= damage;
        healthUI.text = health.ToString();
        
        
        morty.KnockBack(direction);
        
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
