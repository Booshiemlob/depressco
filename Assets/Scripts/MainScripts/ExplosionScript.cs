using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public float ExplosionSize = 0.1f;
    public float ExplosionSizeMax;
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
        transform.localScale += new Vector3(ExplosionSize, ExplosionSize, ExplosionSize);
        ExplosionSize += 0.1f;
        if (ExplosionSize >= ExplosionSizeMax)
        {
            Destroy(gameObject);
        }
    }
}
