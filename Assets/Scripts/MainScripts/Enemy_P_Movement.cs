using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_P_Movement : MonoBehaviour
{
    public GameObject projectile;
    public Transform player;
    public Transform firePoint;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 5f;
    public float stoppingDistance;
    public float retreatDistance;
    private float timeBtwShots;
    public float startTimeBtwShots;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void FixedUpdate()
    {
        Movement2();
        LookAt();
    }
    void Update()
    {
        Shooting();
        //Movement();
    }

    void Movement()
    {
        //If the enemy is too far from the player, it will move towards them.
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        //If the enemy is too close to the player but not close enough to retreat, the enemy will stay stationary.
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && (Vector2.Distance(transform.position, player.position) > retreatDistance))
        {
            transform.position = this.transform.position;
        }
        //If the enemy is too close to the player, the enemy will retreat.
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -moveSpeed * Time.deltaTime);
        }
    }

    void Movement2()
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
            //Fires a bullet and starts a countdown
            //Instantiate(projectile, firePoint.position , firePoint.rotation);
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
}