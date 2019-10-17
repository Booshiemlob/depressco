using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_P_Movement : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public Transform plane;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        TrackPlayer();
    }

    private void FixedUpdate()
    {
        TrackPlayer();

    }
    void TrackPlayer()
    {
        //rb.AddForce(transform.up * -25);
        Vector2 toTarget = player.transform.position - transform.position;
        float speed = 1.5f;

        transform.Translate(toTarget * speed * Time.deltaTime);
        transform.LookAt(plane);
        

    }
}
