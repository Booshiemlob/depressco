using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPulse : MonoBehaviour
{
    public float speed = .1f;
    public Rigidbody2D rb;
    public GameObject[] enemy;
    public float Timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        Invoke("Dead", Timer);
    }

    /*private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }*/

    void Dead()
    {
        Destroy(gameObject);
    }

}
