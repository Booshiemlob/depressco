using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public GameObject backgroundAsset;
    public float ZCoordinate;
    // Start is called before the first frame update
    void Start()
    {
        backgroundAsset.transform.position = new Vector3(transform.position.x,transform.position.y, ZCoordinate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
