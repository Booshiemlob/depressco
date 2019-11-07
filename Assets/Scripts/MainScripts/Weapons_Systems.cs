using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Systems : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform enemypoint;
    public GameObject bullet;
    public GameObject MissilePrefab;
    public GameObject LaserPrefab;
    public int Primary = 0;
    public int Secondary = 1;
    public GameObject[] enemy;

    public Transform LaserEndPoint;
    // Update is called once per frame
    void Update()
    {
        if (Primary == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootBullet();
            }

        }
        if (Primary == 1)
        {
            if (Input.GetButton("Fire1"))
            {
                ShootShotGun();
            }
        }
        if (Primary == 2)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootMissile();
            }
        }
        if(Secondary == 1)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                LaserBeamShoot();
                Debug.Log("Lazer");
            }
        }
        if (Secondary == 2)
        {

        }

        var Rot = firePoint.rotation;
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
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        Instantiate(bullet, firePoint1.position, firePoint1.rotation);
        Instantiate(bullet, firePoint2.position, firePoint2.rotation);
    }


}
