﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public bool f_pressed = false;

    public bool potion_picked = false; 

    public AudioClip PickUpSound;
    public float volume = 1; 
    AudioSource pickup;
    public bool alreadyPlayed = false;

    public MeshRenderer cork;
    public MeshRenderer liquid; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        f_pressed = Input.GetKeyDown("f");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Detected Potion"); 
        if(other.gameObject.CompareTag("Player"))
        {
            if(f_pressed)
            {
                Debug.Log("Player pressed F"); 
                //Play pickup audio
                playPickUpAudio();

                potion_picked = true; 

                //Make potion disappear
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                cork.enabled = false;
                liquid.enabled = false; 
            }
        }
    }


    private void playPickUpAudio()
    {
        if (!alreadyPlayed)
        {
            //Debug.Log("Playing audio");
            //pickup.PlayOneShot(PickUpSound);
            AudioSource.PlayClipAtPoint(PickUpSound, transform.position);
            alreadyPlayed = true;
        }
    }


}
