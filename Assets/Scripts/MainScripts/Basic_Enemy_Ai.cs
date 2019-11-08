using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Enemy_Ai : MonoBehaviour
{
    public GameObject ExplosionBP;
    public GameObject projectile;
    public GameObject[] PowerUps;
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
    public SpawningScript spawnsc;
    public ScoreScript score;
    public bool dead = false;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;

        spawnsc = GameObject.Find("Spawner").GetComponent<SpawningScript>();
        //score = GameObject.Find("scoretext").GetComponent<ScoreScript>();
     
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
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            rb.AddForce(transform.up * moveSpeed*2);
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
        var addAngle = 270;
        var dir = player.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + addAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
                /*float a = Random.Range(0f, 1f);
                if (a <= 0.3f)
                {
                    Instantiate(PowerUps[Random.Range(0, PowerUps.Length)], here.position, here.rotation);
                }*/
                spawnsc.enemyCount--;
                //This adds 1 point to the score
                //score.UpScore();
                Destroy(gameObject);
            }
        }

    }
}