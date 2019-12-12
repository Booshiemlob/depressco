using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Ups : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Dead", 8);
        player = GameObject.FindWithTag("Player").transform;
    }
    void LateUpdate()
    {
        magnet();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
    void magnet()
    {
        //Calculates the distance between the player and the power up, and sets it as dis
        float dis = Vector2.Distance(player.position, this.transform.position);
        //Determines the whether the player is close enough to be magnitized to them.
        if (dis < 20)
        {
            //Speed of the magnet effect
            float speed = 20 - dis;
            speed = speed * Time.deltaTime * 2f;
            transform.position = Vector3.MoveTowards(this.transform.position, player.position, speed);
        }
    }
    void Dead()
    {
        Destroy(gameObject);
    }
}
