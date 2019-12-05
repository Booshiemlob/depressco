using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int ShieldHealth;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Discharge", 15, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (ShieldHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Enemy Bullets"))
        {
            ShieldHealth -= 1;
        }
        if (hitInfo.CompareTag("Enemy"))
        {
            ShieldHealth -= 5;
        }
    }

   void Discharge()
    {
        ShieldHealth -= 1;
    }
}
