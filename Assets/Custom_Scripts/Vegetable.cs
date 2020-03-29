using System.Collections;
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

    public float time = 5f;


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

        if(touchedVege)
        {
           while(time != 0)
            {
                time -= Time.deltaTime; 
            }

            temp.speed = 2; 
        }
    }



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

            temp.speed = 0; 

            //temp.speed = 0.7f;
            this.gameObject.SetActive(false);


            //StartCoroutine(countDown(temp)); 
            //DateTime current = DateTime.Now;

            touchedVege = true; 
           
        }
    }

    /*
    IEnumerator countDown(NavMeshAgent temp)
    {
        Debug.Log("Inside countdown");


        temp.speed = 0; 
        yield return new WaitForSeconds(5);

    }
    */ 


}
