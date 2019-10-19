﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public GameObject[] enemy;
    public float forwardSpeed = 30f;
    public GameObject[] bullets;
    public Transform bullet;
    public int weapon; //Determines which bullet is fired and the fire rate
    public bool reload;
    public List<float> reloadTime;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform LaserEnd;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
      // reload = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        //fireDelay();
    }
    void Movement()
    {
        //Increases player speed if LeftShift if held down
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            forwardSpeed = 50f;
        }
        //Reverts the player speed to normal when LeftShift is let go
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            forwardSpeed = 15f;
        }
        //Turns the player left
            if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(0.5f);
        }
        //turns the player right
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-0.5f);
        }
        //Moves the player forward
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up * forwardSpeed);
        }
        //Moves the player back
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.up * -2);
        }
    }
   /* void fire()
    {
        if(weapon==1)
        {
            //Spawns a bullet
            GameObject clon = (GameObject)Instantiate(bullets[weapon], firePoint1.position, firePoint1.rotation);
            GameObject dank = (GameObject)Instantiate(bullets[weapon], firePoint2.position, firePoint2.rotation);
            GameObject you = (GameObject)Instantiate(bullets[weapon], firePoint3.position, firePoint3.rotation);
            reload = false;
            //Determines the firerate of the player depending on the weapon
            Invoke("recharge", reloadTime[weapon]);

        }
        //Spawns a bullet
        GameObject clone = (GameObject)Instantiate(bullets[weapon], firePoint1.position, firePoint1.rotation);
        reload = false;
        //Determines the firerate of the player depending on the weapon
        Invoke("recharge", reloadTime[weapon]);
       
    }

    void recharge()
    {
        //Sets the bool to allow the player to fire again
        reload = true;
    }
    void fireDelay()
    {
        //if space is pressed fires a bullet, if held down continuously fires a bullet
        if (Input.GetKeyDown(KeyCode.Space) && reload == true)
        {
            InvokeRepeating("fire", 0, 0.5f);     

        }       
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            //Stops the player from shooting
            CancelInvoke("fire");

        }
        
    }*/

    }
