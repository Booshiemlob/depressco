﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Systems : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject MissilePrefab;
    LineRenderer LaserBeam;
    public int WeaponSelected;

    public Transform LaserEndPoint;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            WeaponSelected += 1;

            if (WeaponSelected >= 4)
            {
                WeaponSelected = 0;
            }
        }

        if (WeaponSelected == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootBullet();
            }

        }
        if (WeaponSelected == 1)
        {
            if (Input.GetButton("Fire1"))
            {
                LaserBeamShoot();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                LaserBeam.SetPosition(0, LaserEndPoint.position);
                LaserBeam.SetPosition(1, LaserEndPoint.position);
            }
        }
        if (WeaponSelected == 2)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootMissile();
            }
        }
        if(WeaponSelected == 3)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootShotGun();
            }
        }

        var Rot = firePoint.rotation;
    }

    void ShootBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
 
    }

    void LaserBeamShoot()
    {
        LaserBeam = GetComponent<LineRenderer>();
        LaserBeam.SetPosition(0, firePoint.position);
        LaserBeam.SetPosition(1, LaserEndPoint.position);
    }

    void ShootMissile()
    {
        Instantiate(MissilePrefab, firePoint.position,firePoint.rotation);

    }
    void ShootShotGun()
    {
        /*
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, Random.Range(45, -45)));
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, Random.Range(45, -45)));
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, Random.Range(45, -45)));
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, Random.Range(45, -45)));
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, Random.Range(45, -45)));
        */
    }
}
