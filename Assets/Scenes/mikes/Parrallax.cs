using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrallax : MonoBehaviour
{
    public Transform[] Backgrounds;
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
        PreviousCamPos = cam.position;

        ParrallaxScales = new float[Backgrounds.Length];
        for (int i = 0; i < Backgrounds.Length; i++)
        {
            ParrallaxScales[i] = Backgrounds[i].position.z * -1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       /*for (int i = 0; i < Backgrounds.Length; i++)
        {
            float parrallax = (PreviousCamPos.x - cam.position.x) * ParrallaxScales[i];

            float BackgroundTargetPositionX = Backgrounds[i].position.x + parrallax;

            Vector3 BackgroundTargetPos = new Vector3(BackgroundTargetPositionX, Backgrounds[i].position.y, Backgrounds[i].position.z);

            Backgrounds[i].position = Vector3.Lerp(Backgrounds[i].position, BackgroundTargetPos, Smoothing * Time.deltaTime);
        }*/
    }
}
