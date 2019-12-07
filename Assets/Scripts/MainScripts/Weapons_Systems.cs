using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Systems : MonoBehaviour
{

    public CoolDownUI coolDownUI;
    [Header("UI ICons")]
    //UI Icons
    public GameObject primary1UI;
    public GameObject primary2UI;
    public GameObject primary3UI;
    public GameObject Secondary1UI;
    public GameObject Secondary2UI;
    public GameObject Ultimate1UI;
    public GameObject Ultimate2UI;
    public GameObject Ultimate3UI;


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
    public GameObject TripleShot;
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
    public float PrimaryCooldownAmmount = 0;
    public float SecondaryCooldownAmmount = 0;

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
    //Primary ammo
    public int ammo1;
    //Secondary ammo
    public int ammo2;
    //Mine ammo
    public int ammo3;

    [Space(20)]
    public GameObject[] enemy;

    private GameObject Laser;

    public bool WeaponCheat;

    private void Start()
    {
        primary1UI.SetActive(true);
        primary2UI.SetActive(false);
        primary3UI.SetActive(false);
        Secondary1UI.SetActive(false);
        Secondary2UI.SetActive(false);
        Ultimate1UI.SetActive(false);
        Ultimate2UI.SetActive(false);
        Ultimate3UI.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {

        //developer cheat to quick swap to different weapons to test them out
        if (WeaponCheat == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Primary += 1;
                PrimaryCooldown = 0;
                ammo1 = 1000;
                if (Primary >= 3)
                {
                    Primary = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Secondary += 1;
                SecondaryCooldown = 0;
                ammo2 = 1000;
                if (Secondary >= 4)
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
            primary1UI.SetActive(true);
            primary2UI.SetActive(false);
            primary3UI.SetActive(false);

        }
        if (Primary == 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootTriGun();
            
            }
            primary1UI.SetActive(false);
            primary2UI.SetActive(true);
            primary3UI.SetActive(false);
        }
        if (Primary == 2)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootEnergyPulse();
       
            }
            primary1UI.SetActive(false);
            primary2UI.SetActive(false);
            primary3UI.SetActive(true);
        }
        #endregion

        //seconday weapons
        #region Secondary Weapons
        if (Secondary == 0)
        {
            Secondary1UI.SetActive(false);
            Secondary2UI.SetActive(false);
        }
        if (Secondary == 1)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                ShootMissile();
            }
            Secondary1UI.SetActive(true);
            Secondary2UI.SetActive(false);
        }
        if (Secondary == 2)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                LaserBeamShoot();
            }
            Secondary1UI.SetActive(false);
            Secondary2UI.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            MineShoot();   
        }
        #endregion

        //Ultimate Weapons
        #region Ultimate Weapons
        if(Ultimate == 0)
        {
            Ultimate1UI.SetActive(false);
            Ultimate2UI.SetActive(false);
            Ultimate3UI.SetActive(false);
        }
        if (Ultimate == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EmpBlast();
            }
            Ultimate1UI.SetActive(true);
            Ultimate2UI.SetActive(false);
            Ultimate3UI.SetActive(false);
        }
        if (Ultimate == 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shield();
            }
            Ultimate1UI.SetActive(false);
            Ultimate2UI.SetActive(true);
            Ultimate3UI.SetActive(false);
        }
        if (Ultimate == 3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Helper();
            }
            Ultimate1UI.SetActive(false);
            Ultimate2UI.SetActive(false);
            Ultimate3UI.SetActive(true);
        }
        #endregion

        //CoolDowns

        if(PrimaryCooldown > 0)
        {
            PrimaryCooldown -= PrimaryCooldownAmmount * Time.deltaTime;
        }

        if(SecondaryCooldown > 0)
        {
            SecondaryCooldown -= SecondaryCooldownAmmount*Time.deltaTime;
        }
        if (Secondary == 3 && MineCount < mineCountMax)
        {
            if (SecondaryCooldown <= 0)
            {
                MineCount += 1;
            }
        }

        if (PrimaryCooldown < 0)
        {
            PrimaryCooldown = 0;
        }

        if (SecondaryCooldown < 0)
        {
            SecondaryCooldown = 0;
        }
        coolDownUI.PrimarySetSize(PrimaryCooldown);
        coolDownUI.SecondarySetSize(SecondaryCooldown);


    }

    private void LateUpdate()
    {
        if(ammo1 == 0)
        {
            Primary = 0;
        }
        if(ammo2 == 0)
        {
            Secondary = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        //Changes your primary/secondary weapon based on the power up the player picked up.
        if (hitInfo.CompareTag("Weapon1"))
        {
            Debug.Log("1");
            ammo1 += 10;
            Primary = 1;
 
        }
        if (hitInfo.CompareTag("Weapon2"))
        {
            Debug.Log("2");
            ammo1 += 10;
            Primary = 2;
        }

        if (hitInfo.CompareTag("Weapon3"))
        {
            Debug.Log("3");
            ammo2 += 5;
            Secondary = 1;

        }
        if (hitInfo.CompareTag("Weapon4"))
        {
            Debug.Log("4");
            ammo2 += 5;
            Secondary = 2;
        }
        if (hitInfo.CompareTag("Weapon5"))
        {
            Debug.Log("5");
            Ultimate = 1;
        }
        if (hitInfo.CompareTag("Weapon6"))
        {
            Debug.Log("6");
            Ultimate = 2;
        }
        if (hitInfo.CompareTag("Weapon7"))
        {
            Debug.Log("7");
            Ultimate = 3;
        }
        if (hitInfo.CompareTag("ammo1"))
        {
            Debug.Log("8");
            ammo1 += 10;
        }
        if (hitInfo.CompareTag("ammo2"))
        {
            Debug.Log("9");
            ammo2 += 5;
        }
        if (hitInfo.CompareTag("ammo3"))
        {
            Debug.Log("10");
            MineCount += 1;
        }


    }
    #region primary weapons
    //Regular shooting
    void ShootBullet()
    {
        if (PrimaryCooldown <= 0)
        {
            Instantiate(Bullet, firePoint.position, firePoint.rotation);
            PrimaryCooldownAmmount = SingleShotCooldown;
            PrimaryCooldown = 1;
        }
    }

    //Tri Shooting
    void ShootTriGun()
    {
        if (PrimaryCooldown <= 0 && ammo1 != 0)
        {
            Instantiate(TripleShot, firePoint.position, firePoint.rotation);
            Instantiate(TripleShot, firePoint1.position, firePoint1.rotation);
            Instantiate(TripleShot, firePoint2.position, firePoint2.rotation);
            PrimaryCooldownAmmount = TrippleShotCooldown;
            PrimaryCooldown = 1;
            ammo1--;
        }
    }

    //energy pulse shooting
    void ShootEnergyPulse()
    {
        if (PrimaryCooldown <= 0)
        {
            Instantiate(EnergyPulse, firePoint.position, firePoint.rotation);
            PrimaryCooldownAmmount = EnergyPulseCooldown;
            PrimaryCooldown = 1;
            ammo1--;
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
            SecondaryCooldownAmmount = MissileCooldown;
            SecondaryCooldown = 1;
            ammo2--;
        }
    }

    //Laser Shooting
    void LaserBeamShoot()
    {
        if (SecondaryCooldown <= 0)
        {
            GameObject Laser = Instantiate(LaserPrefab, firePoint.position, firePoint.rotation);
            Laser.transform.parent = this.transform;
            SecondaryCooldownAmmount = LaserCooldown;
            SecondaryCooldown = 1;
            ammo2--;
        }
    }

    // droppping mines
    void MineShoot()
    {
        if (MineCount > 0)
        {
            Instantiate(MinePrefab, firePoint3.position, firePoint3.rotation);
            MineCount -= 1;
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
