using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoDrop : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroy", 10);
    }

    void destroy()
    {

    }

}
