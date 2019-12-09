using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownUI : MonoBehaviour
{
    public Transform PrimaryUI;
    public Transform SecondaryUI;
    public GameObject PrimaryAmmo;
    public GameObject SecondaryAmmo;
    public GameObject MineCount;
    public Weapons_Systems Weapons_Systems;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PrimaryAmmo.GetComponent<Text>().text =" " + Weapons_Systems.ammo1 + "";
        SecondaryAmmo.GetComponent<Text>().text = " " + Weapons_Systems.ammo2 + "";
        MineCount.GetComponent<Text>().text = " " + Weapons_Systems.MineCount + "";
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
