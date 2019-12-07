using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownUI : MonoBehaviour
{
    public Transform PrimaryUI;
    public Transform SecondaryUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrimarySetSize(float sizeNormalized)
    {
        PrimaryUI.localScale = new Vector3(sizeNormalized, 1f);
    }
    public void SecondarySetSize(float sizeNormalized)
    {
        SecondaryUI.localScale = new Vector3(sizeNormalized, 1f);
    }

}
