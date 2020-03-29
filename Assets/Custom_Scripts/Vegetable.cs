﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System; 

public class Vegetable : MonoBehaviour
{
    private bool f_pressed;
    private bool e_pressed;

    private bool touchedVege; 

    public float speed = 1000f; 
    //public GameObject vege; 
    public Transform p; //player 

    private NavMeshAgent temp;

    public float time = 5000f; 


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        f_pressed = Input.GetKeyDown("f");
       
        /*
        e_pressed = Input.GetKeyDown("e"); 

        if (e_pressed)
        {
            Debug.Log("Pressed e");
            this.gameObject.SetActive(true);
            //transform.position = Vector3.MoveTowards(transform.position, p.position, speed * Time.deltaTime); 
            //Instantiate(vege, p.position, Quaternion.identity); 
        }
        */
    }

    /*
    void Update()
    {
        if (touchedVege)
        {
            Debug.Log("inside touchedVEGE true");

            float start = Time.deltaTime;

            while (time != 0)
            {
                float diff = Time.deltaTime - start;
                Debug.Log(diff); 
                if (diff >= 5f)
                {
                    temp.speed = 2;
                    time = 0;
                }
            }
        }
    }
    */ 

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Found player by vegetable"); 
            if(f_pressed)
            {
                this.gameObject.SetActive(false); 
            }
        }

        if(other.gameObject.CompareTag("AI"))
        {
            Debug.Log("AI ennemy detected");
            temp = other.gameObject.GetComponent<NavMeshAgent>();

            //temp.speed = 0; 

            //temp.speed = 0.7f;


            StartCoroutine(countDown(temp));

            Debug.Log("Counted 5 seconds");
            temp.speed = 2;

            //DateTime current = DateTime.Now;

            //touchedVege = true;
            //Debug.Log(touchedVege); 
        }
    }

    
    IEnumerator countDown(NavMeshAgent temp)
    {
        Debug.Log("Inside countdown");

        this.gameObject.SetActive(false);
        temp.speed = 0; 
        yield return new WaitForSeconds(time);

    }
    


}
