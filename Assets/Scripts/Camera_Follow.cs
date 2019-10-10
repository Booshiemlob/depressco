using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    //public GameObject player;
    public float FollowSpeed = 120f;
    public Transform Target;

    //public float smoothSpeed = 0.125f;
    //public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        /*player = GameObject.Find("player");
        offset = new Vector3(0, 0, -7);*/
    }

    void Update()
    {
        //This controls the camera so that it follows the crate while ignoring the rotation of the crate
        Vector3 newPosition = Target.position;
        newPosition.z = -5.5f;
       

        transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * 4.5f * Time.deltaTime);
    }

}
// Update is called once per frame
/* void FixedUpdate()
 {
     TrackPlayer();
     OffsetPosition();
 }

void TrackPlayer()
 {
     Vector3 desiredPosition = target.position + offset;
     Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
     transform.position = smoothedPosition;
 }
 void OffsetPosition()
 {
     if(player.transform.rotation.eulerAngles.z>=270& player.transform.rotation.eulerAngles.z < 360)
     {
         offset = new Vector3(2, 1, -7);
     }
     if(player.transform.rotation.eulerAngles.z>0& player.transform.rotation.eulerAngles.z< 90)
     {
         offset = new Vector3(-2, 1, -7);
     }
     if(player.transform.rotation.eulerAngles.z>= 90 & player.transform.rotation.eulerAngles.z < 180)
     {
         offset = new Vector3(-2, -1, -7);
     }
     if (player.transform.rotation.eulerAngles.z>= 180 & player.transform.rotation.eulerAngles.z < 270)
     {
         offset = new Vector3(2, -1, -7);
     }
 }
}*/
