using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    int size = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("explosion", 0, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void explosion()
    {
        transform.localScale += new Vector3(size, size, size);
        size += 1;
        if (size >= 10)
        {
            Destroy(gameObject);
        }
    }
}