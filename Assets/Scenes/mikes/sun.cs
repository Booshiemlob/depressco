using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour
{
   
    public Transform Player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = Player.transform.position;
        temp.x = temp.x + 8;
        // Assign value to Camera position
        transform.position = new Vector3(temp.x,transform.position.y,transform.position.z);
        
    }
}
