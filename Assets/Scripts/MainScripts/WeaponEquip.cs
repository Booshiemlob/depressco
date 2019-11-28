using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponEquip : MonoBehaviour
{
    //Weapon Equipped
    public Weapons_Systems weapScr;
    public TMP_Text weapEq1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weapScr.Primary == 0)
        {
            weapEq1.GetComponent<TMP_Text>().text = "Single Shot";
        }
       if (weapScr.Primary == 1)
        {
            weapEq1.GetComponent<TMP_Text>().text = "Triple Shot";
        }
        if (weapScr.Primary == 2) 
        {
            weapEq1.GetComponent<TMP_Text>().text = "Pulse Wave";
        }
    }
}
    