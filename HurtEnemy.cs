using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageGiven;

    private void OnTriggerEnter(Collider other)
    {


        //check for character collider - may eventually add enemy tags - enemy runs into cactus
        if (other.tag == "Enemy") 
        {
            other.gameObject.GetComponent<EnemyController>().enemCurrHealth -= damageGiven;
        }
    }
}
