using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Enemy_Ai : MonoBehaviour
{
    public GameObject ExplosionBP;
    public GameObject projectile;
    public List<GameObject> primary = new List<GameObject>();
    public List<GameObject> secondary = new List<GameObject>();
    public List<GameObject> ultimate = new List<GameObject>();
    public List<GameObject> ammo = new List<GameObject>();
    public Transform here;
    public Transform player;
    public Transform firePoint;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 5f;
    public float stoppingDistance;
    public float retreatDistance;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float rand;
    public int rand2;
    public int rand3;
    public SpawningScript spawnsc;
    public ScoreScript score;
    public Weapons_Systems weapon;
    public bool dead = false;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        if(GameObject.FindWithTag("Player") != null)
            player = GameObject.FindWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;

        spawnsc = GameObject.Find("Spawner").GetComponent<SpawningScript>();
        score = GameObject.Find("scoretext").GetComponent<ScoreScript>();
        weapon = GameObject.Find("player").GetComponent<Weapons_Systems>();

    }

    void FixedUpdate()
    {
        Movement();
        LookAt();
    }
    void Update()
    {
        Shooting();

    }

    void Movement()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                rb.AddForce(transform.up * moveSpeed * 2);
            }
            //If the enemy is too close to the player but not close enough to retreat, the enemy gain nor lose velocity.
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && (Vector2.Distance(transform.position, player.position) > retreatDistance))
            {
                transform.position = this.transform.position;
            }
            //If the enemy is too close to the player, the enemy will retreat.
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                rb.AddForce(transform.up * -moveSpeed);
            }
        }
    }

    void Shooting()
    {
        if(timeBtwShots <= 0)
        {
            timeBtwShots = startTimeBtwShots;
            //Fires a bullet and starts a countdown
            Instantiate(projectile, firePoint.position , firePoint.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            //Timer for how fast it shoots
            timeBtwShots -= Time.deltaTime;
        }
    }
    void LookAt()
    {
        //Looks at player.
        if (GameObject.FindWithTag("Player") != null)
        {
            var addAngle = 270;
            var dir = player.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + addAngle;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Checks if it was hit by a player bullet.
        if (hitInfo.CompareTag("Player Bullets"))
        {
            
            if (dead == false)
            {

                //Destroys the enemy, spawns an explosion and notifies the enemy spawner.
                GameObject clone = (GameObject)Instantiate(ExplosionBP, here.position, here.rotation);
                dead = true;
                //Random chance to spawn a random weapon power up.
                rand = Random.Range(0f, 1f);
                rand2 = Random.Range(0, 11);
                if (rand >= 0.6f)
                {
                    if (rand2 <= 3)
                    {
                        if (weapon.Primary == 0)
                        {
                            Debug.Log("Primary 1");
                            Instantiate(primary[Random.Range(0, primary.Count)], here.position, Quaternion.Euler(0, 0, 0));
                        }
                        else
                        {
                            if (rand2 < 3)
                            {
                                if (weapon.Primary == 1)
                                {
                                    Debug.Log("Primary 2");
                                    Instantiate(primary[1], here.position, Quaternion.Euler(0, 0, 0));
                                }
                                else
                                {
                                    Debug.Log("Primary 3");
                                    Instantiate(primary[0], here.position, Quaternion.Euler(0, 0, 0));
                                }
                            }
                            else
                            {
                                Debug.Log("Primary 4");
                                Instantiate(ammo[0], here.position, Quaternion.Euler(0, 0, 0));
                            }
                        }
                    }

                    if (4 <= rand2 && rand2 < 6)
                    {
                        if (weapon.Secondary == 0)
                        {
                            Debug.Log("Secondary 1");
                            Instantiate(secondary[Random.Range(0, secondary.Count)], here.position, Quaternion.Euler(0, 0, 0));
                        }
                        else
                        {
                            if (rand2 < 3)
                            {
                                if (weapon.Secondary == 1)
                                {
                                    Debug.Log("Secondary 2");
                                    Instantiate(secondary[0], here.position, Quaternion.Euler(0, 0, 0));
                                }
                                else
                                {
                                    Debug.Log("Secondary 3");
                                    Instantiate(secondary[1], here.position, Quaternion.Euler(0, 0, 0));
                                }
                            }
                            else
                            {
                                Debug.Log("Secondary 4");
                                Instantiate(ammo[1], here.position, Quaternion.Euler(0, 0, 0));
                            }
                        }
                    }
                    if (rand2 == 6)
                    {
                        if (weapon.Ultimate == 0)
                        {
                            Debug.Log("Ultimate 1");
                            Instantiate(ultimate[Random.Range(0, ultimate.Count)], here.position, Quaternion.Euler(0, 0, 0));
                        }
                        else
                        {
                            if (weapon.Ultimate == 1)
                            {
                                Debug.Log("Ultimate 2");
                                Instantiate(ultimate[Random.Range(1, ultimate.Count)], here.position, Quaternion.Euler(0, 0, 0));
                            }
                            if (weapon.Ultimate == 2)
                            {
                                Debug.Log("Ultimate 3");
                                rand2 = Random.Range(0, 2);
                                if (rand2 == 1)
                                {
                                    Instantiate(ultimate[0], here.position, Quaternion.Euler(0, 0, 0));
                                }
                                else
                                {
                                    Instantiate(ultimate[2], here.position, Quaternion.Euler(0, 0, 0));
                                }

                            }
                            if (weapon.Ultimate == 3)
                            {
                                Debug.Log("Ultimate 4");
                                rand2 = Random.Range(0, 2);
                                if (rand2 == 1)
                                {
                                    Instantiate(ultimate[0], here.position, Quaternion.Euler(0, 0, 0));
                                }
                                else
                                {
                                    Instantiate(ultimate[1], here.position, Quaternion.Euler(0, 0, 0));
                                }

                            }

                            Debug.Log("5");
                            Instantiate(ammo[2], here.position, Quaternion.Euler(0, 0, 0));
                        }
                    }
                    if (rand2 >= 7)
                    {
                        Debug.Log("ammo");
                        Instantiate(ammo[Random.Range(0, ammo.Count)], here.position, Quaternion.Euler(0, 0, 0));
                    }
                }
                spawnsc.enemies.Remove(this.transform);
                spawnsc.enemyCount--;
                //This adds 1 point to the score
                score.UpScore();
                Destroy(gameObject);
            }
        }

    }
}