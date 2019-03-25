using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource mainBacking;
    public MortimerController morty;
    public AudioSource footSteps;
    public AudioSource jumping;
    public AudioSource gemSound;

    // Start is called before the first frame update
    void Start()
    {
        mainBacking.volume = .1f;
        mainBacking.Play();
        footSteps.Stop();
        jumping.Stop();
        gemSound.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PauseMenu.paused)
        {
            mainBacking.volume = .05f;
        }
        else
        {
            mainBacking.volume = .1f;
        }
        if (morty.roll)
        {
            footSteps.Stop();
        }
        if(morty.GetComponent<CharacterController>().isGrounded && morty.GetComponent<CharacterController>().velocity.magnitude > 2f && !footSteps.isPlaying)
        {
            footSteps.volume = .6f;
            if (morty.sprint)
            {
                footSteps.pitch = 1.5f;
            }
            else if(!morty.sprint)
            {
                footSteps.pitch = 1f;
            }

            footSteps.Play();
        }

       
    }

    public void Jumping()
    {
        jumping.pitch = .6f;
        jumping.volume = .2f;
        jumping.Play();
    }



    public void GemSound()
    {
        gemSound.volume = .5f;
        gemSound.Play();
    }
}
