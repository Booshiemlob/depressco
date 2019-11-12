using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    public float LaserFiretime;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("dead", LaserFiretime);
    }
    private void Update()
    {
        if (Input.GetButtonUp("Fire2"))
        {
            Destroy(gameObject);
        }
    }

    void dead()
    {
        Destroy(gameObject);
    }

}