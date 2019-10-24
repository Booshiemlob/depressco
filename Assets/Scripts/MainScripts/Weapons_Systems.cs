using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Systems : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform enemypoint;
    public GameObject bulletPrefab;
    public GameObject MissilePrefab;
    public GameObject LaserPrefab;
    public int WeaponSelected;
    public GameObject[] enemy;

    public Transform LaserEndPoint;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            WeaponSelected += 1;

            if (WeaponSelected >= 5)
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
        if (WeaponSelected == 4)
        {
            if (Input.GetButton("Fire1"))
            {
                energySyphon();
            }
        }

        var Rot = firePoint.rotation;
    }
    //Regular shooting
    void ShootBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
 
    }
    //Laser Shooting
    void LaserBeamShoot()
    {
        Instantiate(LaserPrefab, firePoint.position, firePoint.rotation);
    }

    void energySyphon()
    {

    }
    //Missile Shooting
    void ShootMissile()
    {
        Instantiate(MissilePrefab, firePoint.position,firePoint.rotation);

    }
    //Shotgun Shooting
    void ShootShotGun()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
    }
}
