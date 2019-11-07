using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    //Background Objects
    public GameObject[] BackgroundObjectBig;
    public GameObject[] BackgroundObjectMedium;
    public GameObject[] BackgroundObjectSmall;

    // X coordinate range
    public float XPosMax;
    public float XNegMax;

    // Y coordinate range
    public float YPosMax;
    public float YNegMax;

    // background Spawn Count
    public int SpawnCountBig;
    public int SpawnCountMedium;
    public int SpawnCountSmall;

    // Start is called before the first frame update
    void Start()
    {
        // Spawns small objects around the screen
        for (int i = 0; i < SpawnCountSmall; i++)
        {
            //creates a random range for each axis
            float Xrange = Random.Range(XPosMax, XNegMax);
            float Yrange = Random.Range(YPosMax, YNegMax);

            //create a gameobject then moves it to the random position within the limits
            GameObject BackgroundItem = Instantiate(BackgroundObjectSmall[Random.Range(0, BackgroundObjectSmall.Length)]);
            BackgroundItem.transform.position = new Vector3(Xrange, Yrange, 0);
        }

        // Spawns medium objects around the background
        for (int i = 0; i < SpawnCountMedium; i++)
        {
            //creates a random range for each axis
            float Xrange = Random.Range(XPosMax, XNegMax);
            float Yrange = Random.Range(YPosMax, YNegMax);

            //create a gameobject then moves it to the random position within the limits
            GameObject BackgroundItem = Instantiate(BackgroundObjectMedium[Random.Range(0, BackgroundObjectMedium.Length)]);
            BackgroundItem.transform.position = new Vector3(Xrange, Yrange, 0);
        }

        // Spawns big objects around the room
        for (int i = 0; i < SpawnCountBig; i++)
        {
            //creates a random range for each axis
            float Xrange = Random.Range(XPosMax, XNegMax);
            float Yrange = Random.Range(YPosMax, YNegMax);

            //create a gameobject then moves it to the random position within the limits
            GameObject BackgroundItem = Instantiate(BackgroundObjectBig[Random.Range(0, BackgroundObjectBig.Length)]);
            BackgroundItem.transform.position = new Vector3(Xrange, Yrange, 0);
        }
    }
    //maybe adding a z axis move script to the gameobject for parralax background

    // Update is called once per frame
    void Update()
    {
        
    }
}
