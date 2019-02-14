using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public int health;
    public int maximumHealth;

    public MortimerController morty;
    // Start is called before the first frame update
    void Start()
    {
        health = maximumHealth;

        morty = FindObjectOfType<MortimerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtPlayer(int damage, Vector3 direction)
    {
        health -= damage;

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
