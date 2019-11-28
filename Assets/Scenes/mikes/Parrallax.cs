using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrallax : MonoBehaviour
{

    private float[] ParrallaxScales;
    public float Smoothing = 1f;
    private Transform cam;
    private Vector3 PreviousCamPos;
    public BackgroundSpawner spawner;

    void Awake()
    {
        cam = Camera.main.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        /*for(int i = 0; i < Backgrounds.Length; i++)
        {
            Backgrounds = GameObject.FindGameObjectsWithTag("BackgroundAsset");
        }*/

        spawner = GameObject.Find("Background Colour").GetComponent<BackgroundSpawner>();

        foreach (GameObject bg in GameObject.FindGameObjectsWithTag("BackgroundAsset"))
        {
            spawner.Backgrounds.Add(bg);
        }


            PreviousCamPos = cam.position;

        ParrallaxScales = new float[spawner.Backgrounds.Count];
        for (int i = 0; i < spawner.Backgrounds.Count; i++)
        {
            ParrallaxScales[i] = spawner.Backgrounds[i].transform.position.z * -1;
        }
        
        //grabs background and attachs it to the parralax
    }

    // Update is called once per frame
    void Update()
    {
        if (spawner.Backgrounds.Count < 0)
        {
            for (int i = 0; i < spawner.Backgrounds.Count; i++)
            {
                float parrallax = (PreviousCamPos.x - cam.position.x) * ParrallaxScales[i];

                float BackgroundTargetPositionX = spawner.Backgrounds[i].transform.position.x + parrallax;

                Vector3 BackgroundTargetPos = new Vector3(BackgroundTargetPositionX, spawner.Backgrounds[i].transform.position.y, spawner.Backgrounds[i].transform.position.z);

                spawner.Backgrounds[i].transform.position = Vector3.Lerp(spawner.Backgrounds[i].transform.position, BackgroundTargetPos, Smoothing * Time.deltaTime);
            }
        }
    }
}
