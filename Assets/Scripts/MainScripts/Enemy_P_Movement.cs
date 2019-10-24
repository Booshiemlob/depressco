using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_P_Movement : MonoBehaviour
{
    public GameObject ExplosionBP;
    public GameObject projectile;
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
    private SpawningScript spawnsc;
    public bool dead = false;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;

        spawnsc = GameObject.Find("Spawner").GetComponent<SpawningScript>();
     
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
        var addAngle = 270;
        var dir = player.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + addAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player Bullets"))
        {

            if (dead == false)
            {
                GameObject clone = (GameObject)Instantiate(ExplosionBP, here.position, here.rotation);
                spawnsc.enemyCount--;
                Debug.Log(spawnsc.enemyCount);
                dead = true;
                Destroy(gameObject);
            }
        }
        if (hitInfo.CompareTag("Player"))
        {
            if (dead == false)
            {
                GameObject clone = (GameObject)Instantiate(ExplosionBP, here.position, here.rotation);
                spawnsc.enemyCount--;
                Debug.Log(spawnsc.enemyCount);
                dead = true;
                Destroy(gameObject);
            }
        }
    }
}