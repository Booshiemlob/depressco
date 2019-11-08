using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Systems : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint1;
    public Transform firePoint2;
    public GameObject bullet;
    public GameObject MissilePrefab;
    public GameObject LaserPrefab;
    public GameObject EmpPrefab;
    public int Primary = 0;
    public int Secondary = 0;
    public GameObject[] enemy;

    public bool WeaponCheat;

    public Transform LaserEndPoint;
    // Update is called once per frame
    void Update()
    {
        //developer cheat to quick swap to different weapons to test them out
        if (WeaponCheat == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Primary += 1;
                if(Primary >= 2)
                {
                    Primary = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Secondary += 1;
                if(Secondary >= 3)
                {
                    Secondary = 0;
                }
            }
        }

        if (Primary == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootBullet();
            }

        }
        if (Primary == 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootTriGun();
            }
        }
        if (Secondary == 0)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                ShootMissile();
            }
        }
        if (Secondary == 1)
        {
            if (Input.GetButton("Fire2"))
            {
                LaserBeamShoot();
            }
        }
        if (Secondary == 2)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                EmpBlast();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Changes your primary/secondary weapon based on the power up the player picked up.
        if (hitInfo.CompareTag("Weapon1"))
        {
            Primary = 1;
        }
        if (hitInfo.CompareTag("Weapon2"))
        {
            Primary = 2;
        }
        if (hitInfo.CompareTag("Weapon3"))
        {
            Primary = 3;
        }

        if (hitInfo.CompareTag("Weapon4"))
        {
            Secondary = 1;
        }
        if (hitInfo.CompareTag("Weapon5"))
        {
            Secondary = 2;
        }

    }
    //Regular shooting
    void ShootBullet()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
 
    }
    //Laser Shooting
    void LaserBeamShoot()
    {
        Instantiate(LaserPrefab, firePoint.position, firePoint.rotation);
    }

    //Missile Shooting
    void ShootMissile()
    {
        Instantiate(MissilePrefab, firePoint.position,firePoint.rotation);

    }
    //Tri Shooting
    void ShootTriGun()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        Instantiate(bullet, firePoint1.position, firePoint1.rotation);
        Instantiate(bullet, firePoint2.position, firePoint2.rotation);
    }

    void EmpBlast()
    {
        Instantiate(EmpPrefab, firePoint.position, firePoint.rotation);
    }


}
