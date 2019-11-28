using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Suicide_Ai : MonoBehaviour
{
    public GameObject ExplosionBP;
    public List<GameObject> primary = new List<GameObject>();
    public List<GameObject> secondary = new List<GameObject>();
    public List<GameObject> ultimate = new List<GameObject>();
    public List<GameObject> ammo = new List<GameObject>();
    public Transform here;
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 7f;
    public float rand;
    public int rand2;
    public SpawningScript spawnsc;
    public ScoreScript score;
    public Weapons_Systems weapon;

    public bool dead = false;



    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
       
        spawnsc = GameObject.Find("Spawner").GetComponent<SpawningScript>();
        //This finds the text for the score.
        score = GameObject.Find("scoretext").GetComponent<ScoreScript>();
        if (GameObject.Find("player") != null)
        {
            weapon = GameObject.Find("player").GetComponent<Weapons_Systems>();
        }

    }

    void FixedUpdate()
    {
        if (GameObject.Find("player") != null)
        {
            player = GameObject.FindWithTag("Player").transform;
            rb.AddForce(transform.up * moveSpeed * 2);
            LookAt();
        }
        
    }
    void LateUpdate()
    {
        if (dead == true)
        {
            Destroy(gameObject);
        }
    }

    void LookAt()
    {
        //Looks at the player.
        var addAngle = 270;
        var dir = player.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + addAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("Player Bullets"))
        {

            if (dead == false)
            {
                //Destroys the ship and explodes, removing a count from the enemyCount.
                GameObject clone = (GameObject)Instantiate(ExplosionBP, here.position, here.rotation);
                spawnsc.enemies.Remove(this.transform);
                spawnsc.enemyCount--;
                //Random chance to spawn a random weapon power up.
                rand = Random.Range(0f, 1f);
                rand2 = Random.Range(0, 11);
                Debug.Log("rand2 " + rand2);
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
                //This adds 1 to the score
                score.UpScore();
                dead = true;
            }
        }
    }   
}
