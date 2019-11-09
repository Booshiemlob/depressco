using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrallax : MonoBehaviour
{
    public GameObject[] Backgrounds = new GameObject[100];
    private float[] ParrallaxScales;
    public float Smoothing = 1f;
    private Transform cam;
    private Vector3 PreviousCamPos;

    void Awake()
    {
        cam = Camera.main.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Backgrounds.Length; i++)
        {
            Backgrounds = GameObject.FindGameObjectsWithTag("BackgroundAsset");
        }
        
        
            PreviousCamPos = cam.position;

        ParrallaxScales = new float[Backgrounds.Length];
        for (int i = 0; i < Backgrounds.Length; i++)
        {
            ParrallaxScales[i] = Backgrounds[i].transform.position.z * -1;
        }
        
        //grabs background and attachs it to the parralax
    }

    // Update is called once per frame
    void Update()
    {
        if (Backgrounds.Length < 0)
        {
            for (int i = 0; i < Backgrounds.Length; i++)
            {
                float parrallax = (PreviousCamPos.x - cam.position.x) * ParrallaxScales[i];

                float BackgroundTargetPositionX = Backgrounds[i].transform.position.x + parrallax;

                Vector3 BackgroundTargetPos = new Vector3(BackgroundTargetPositionX, Backgrounds[i].transform.position.y, Backgrounds[i].transform.position.z);

                Backgrounds[i].transform.position = Vector3.Lerp(Backgrounds[i].transform.position, BackgroundTargetPos, Smoothing * Time.deltaTime);
            }
        }
    }
}
