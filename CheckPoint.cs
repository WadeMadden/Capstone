using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CheckPoint : MonoBehaviour
{
    public HealthManager mortHealthMan;

    public Renderer theRend;

    public Material cpOff;
    public Material cpOn;

    
    // Start is called before the first frame update
    void Start()
    {
        mortHealthMan = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckpointOn()
    {
        CheckPoint[] checkpoints = FindObjectsOfType<CheckPoint>();
        foreach(CheckPoint point in checkpoints){
            point.CheckpointOff();
        }

        theRend.material = cpOn;
    }

    public void CheckpointOff()
    {
        theRend.material = cpOff;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            mortHealthMan.SetSpawnPoint(transform.position);
            CheckpointOn();
        }
    }
}
