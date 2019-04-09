using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public AudioManager audMan;
    public int damageGiven;

    private void Start()
    {
        GetComponent<Collider>().enabled = false;
    }

    void Update()
    {
        if (FindObjectOfType<MortimerController>().attack != -1)
        {
            StartCoroutine(HoldTrue());
        }
    }

    private IEnumerator HoldTrue()
    {
        GetComponent<CapsuleCollider>().enabled = true;
        yield return new WaitForSeconds(1);
        GetComponent<Collider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {


        //check for character collider - may eventually add enemy tags - enemy runs into cactus
        if (other.tag == "Enemy") 
        {
            audMan.LionHurt();
            other.gameObject.GetComponent<EnemyController>().enemCurrHealth -= damageGiven;
        }
    }
}
