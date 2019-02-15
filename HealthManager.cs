using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthManager : MonoBehaviour
{

    public int health;
    public int maximumHealth;
    public Text healthUI;
    public TextMeshProUGUI h;

    public MortimerController morty;
    // Start is called before the first frame update
    void Start()
    {
        //h = GetComponent<TextMeshProUGUI>();
        health = maximumHealth;
        healthUI.text = "" + health;
        //h.text = health.ToString();
        morty = FindObjectOfType<MortimerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtPlayer(int damage, Vector3 direction)
    {
        
        health -= damage;
        //h.text = health.ToString();
        healthUI.text = "" + health;
        
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
