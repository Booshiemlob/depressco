using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Systems : MonoBehaviour
{
    [Header("Fire Points")]
    // Player FirePoints
    public Transform firePoint;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;

    [Header("Weapon Prefabs")]
    //primary Weapons
    public GameObject Bullet;
    public GameObject EnergyPulse;

    //secondary Weapons
    public GameObject MissilePrefab;
    public GameObject LaserPrefab;
    public GameObject MinePrefab;

    //Ultimate Weapons
    public GameObject EmpPrefab;
    public GameObject ShieldPrefab;
    public GameObject HelperPrefab;

    [Header("Selected Weapons")]
    // Weapon Selected variables
    public int Primary = 0;
    public int Secondary = 0;
    public int Ultimate = 0;

    [Header("Weapon Cooldown time")]
    //weapon Cooldowns
    public float PrimaryCooldown = 0;
    public float SecondaryCooldown = 0;

    [Header("Each weapon cooldown")]
    public float SingleShotCooldown;
    public float TrippleShotCooldown;
    public float EnergyPulseCooldown;
    [Space(10)]
    public float MissileCooldown;
    public float LaserCooldown;
    public float MineCooldown;
    public int MineCount;
    public int mineCountMax;

    [Space(20)]
    public GameObject[] enemy;

    private GameObject Laser;

    public bool WeaponCheat;

    // Update is called once per frame
    void Update()
    {
        //developer cheat to quick swap to different weapons to test them out
        if (WeaponCheat == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Primary += 1;
                PrimaryCooldown = 0;
                if (Primary >= 3)
                {
                    Primary = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Secondary += 1;
                SecondaryCooldown = 0;
                if(Secondary >= 4)
                {
                    Secondary = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Ultimate += 1;
                if(Ultimate >= 4)
                {
                    Ultimate = 0;
                }
            }
        }
        //primary Weapons
        #region primary Weapons
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
        if (Primary == 2)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootEnergyPulse();
       
            }
        }
        #endregion

        //seconday weapons
        #region Secondary Weapons
        if (Secondary == 1)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                ShootMissile();
          
            }
        }
        if (Secondary == 2)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                LaserBeamShoot();
             
            }
        }
        if (Secondary == 3)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                MineShoot();
                
            }
        }
        #endregion

        //Ultimate Weapons
        #region Ultimate Weapons
        if (Ultimate == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EmpBlast();
            }
        }
        if (Ultimate == 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shield();
            }
        }
        if (Ultimate == 3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Helper();
            }
        }
        #endregion

        //CoolDowns

        if(PrimaryCooldown > 0)
        {
            PrimaryCooldown -= 1 * Time.deltaTime;
        }

        if(SecondaryCooldown > 0)
        {
            SecondaryCooldown -= 1*Time.deltaTime;
        }
        if (Secondary == 3 && MineCount < mineCountMax)
        {
            if (SecondaryCooldown <= 0)
            {
                MineCount += 1;
            }
        }
    }

    /*private void OnTriggerEnter2D(Collider2D hitInfo)
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
        

    }*/
    #region primary weapons
    //Regular shooting
    void ShootBullet()
    {
        if (PrimaryCooldown <= 0)
        {
            Instantiate(Bullet, firePoint.position, firePoint.rotation);
            PrimaryCooldown = SingleShotCooldown;
        }
    }

    //Tri Shooting
    void ShootTriGun()
    {
        if (PrimaryCooldown <= 0)
        {
            Instantiate(Bullet, firePoint.position, firePoint.rotation);
            Instantiate(Bullet, firePoint1.position, firePoint1.rotation);
            Instantiate(Bullet, firePoint2.position, firePoint2.rotation);
            PrimaryCooldown = TrippleShotCooldown;
        }
    }

    //energy pulse shooting
    void ShootEnergyPulse()
    {
        if (PrimaryCooldown <= 0)
        {
            Instantiate(EnergyPulse, firePoint.position, firePoint.rotation);
            PrimaryCooldown = EnergyPulseCooldown;
        }
    }
    #endregion

    #region secondary weapons
    //Missile Shooting
    void ShootMissile()
    {
        if (SecondaryCooldown <= 0)
        {
            Instantiate(MissilePrefab, firePoint.position, firePoint.rotation);
            SecondaryCooldown = MissileCooldown;
        }
    }

    //Laser Shooting
    void LaserBeamShoot()
    {
        if (SecondaryCooldown <= 0)
        {
            GameObject Laser = Instantiate(LaserPrefab, firePoint.position, firePoint.rotation);
            Laser.transform.parent = this.transform;
            SecondaryCooldown = LaserCooldown;
        }
    }

    // droppping mines
    void MineShoot()
    {
        if (MineCount > 0)
        {
            Instantiate(MinePrefab, firePoint3.position, firePoint3.rotation);
            MineCount -= 1;
            SecondaryCooldown += MineCooldown; 


        }
    }
    #endregion

    #region ultimate weapons
    //Emp Blast
    void EmpBlast()
    {
        Instantiate(EmpPrefab, firePoint4.position, firePoint4.rotation);
        Ultimate = 0;
    }

    //shield
    void Shield()
    {
        GameObject g = Instantiate(ShieldPrefab, firePoint4.position, firePoint4.rotation);
        g.transform.parent = this.transform;
        Ultimate = 0;
    }

    //helper drone
    void Helper()
    {
        Instantiate(HelperPrefab, firePoint3.position, firePoint3.rotation);
        Ultimate = 0;
    }
    #endregion
}
