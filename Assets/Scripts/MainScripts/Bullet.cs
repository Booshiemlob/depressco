using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = .1f;
    public Rigidbody2D rb;
    public GameObject[] enemy;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        Invoke("dead", 5);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        Destroy(gameObject);
    }

    void dead()
    {
        Destroy(gameObject);
    }

}
