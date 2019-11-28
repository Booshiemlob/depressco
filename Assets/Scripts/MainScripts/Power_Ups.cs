using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Ups : MonoBehaviour
{
    public Transform player;
    public Transform here;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
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
        float dis = Vector2.Distance(player.position, here.position);
        if (dis < 5)
        {
            float speed = 5 - dis;
            speed = speed * Time.deltaTime * 1.5f;
            transform.position = Vector3.MoveTowards(here.position, player.position, speed);
        }
    }
}
