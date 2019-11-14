using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Suicide_Ai : MonoBehaviour
{
    public GameObject ExplosionBP;
    public GameObject[] PowerUps;
    public Transform here;
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 7f;
    public float rand;
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
                dead = true;
                //Random chance to spawn a random weapon power up.
                rand = Random.Range(0f, 1f);
                if (weapon.Primary == 0)
                {
                    if (rand >= 0f)
                    {
                        Instantiate(PowerUps[Random.Range(0, PowerUps.Length)], here.position, here.rotation);
                    }
                }
                if (weapon.Primary != 0)
                {
                    weapon.ammo1 += 10;
                }
                //This adds 1 to the score
                score.UpScore();
                Destroy(gameObject);
            }


        }
    }   
}
