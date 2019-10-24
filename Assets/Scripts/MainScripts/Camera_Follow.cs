using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{

    public float FollowSpeed = 120f;
    public Transform Target;


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        //This controls the camera so that it follows the crate while ignoring the rotation of the crate
        Vector3 newPosition = Target.position;
        newPosition.z = -5.5f;
       

        transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * 4.5f * Time.deltaTime);
    }

}

