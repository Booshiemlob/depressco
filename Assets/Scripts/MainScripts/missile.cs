using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    public float speed = 0.1f;
    public Rigidbody2D rb;
    public GameObject ExplosionBP;
    public Transform missileob;
    public GameObject[] enemy;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        Invoke("Shoot", 5);
    }



    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Enemy"))
        {
            Shoot();
        }


    }

    void Shoot()
    {
        Destroy(gameObject);

        Explosion();
    }
    void Explosion()
    {
        GameObject clone = (GameObject)Instantiate(ExplosionBP, missileob.position, missileob.rotation);
    }

}
