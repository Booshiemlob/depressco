using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    float size = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("explosion", 0, 0.075f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void explosion()
    {
        transform.localScale += new Vector3(size, size, size);
        size += 0.1f;
        if (size >= 0.5f)
        {
            Destroy(gameObject);
        }
    }
}