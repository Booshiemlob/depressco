using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigText : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
       gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void biggerOnScreen()
    {
        gameObject.SetActive(true);
    }
}
