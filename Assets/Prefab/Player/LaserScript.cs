using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject[] enemy;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("dead", 0.01f);
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