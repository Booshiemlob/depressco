using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper_AI : MonoBehaviour
{
    public GameObject projectile;
    public Transform here;
    public Transform player;
    public Transform closestEnemy;
    public List<Transform> currentEnemies = new List<Transform>();
    public Transform firePoint;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 5f;
    public float stoppingDistance;
    public float retreatDistance;
    private float timeBtwShots;
    public float startTimeBtwShots;
    private float distToClosestEnemy;
    private float distanceToEnemy;
    public float DeathTimer;
    public SpawningScript spawnsc;

    void Start()
    {

        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        spawnsc = GameObject.Find("Spawner").GetComponent<SpawningScript>();
        timeBtwShots = startTimeBtwShots;
        Invoke("dead", DeathTimer);
    }

    void FixedUpdate()
    {
        FindClosestEnemy();
        Movement();
        LookAt();
    }

    void Update()
    {
        Shooting();
    }
    void Movement()
    {
        if (Vector2.Distance(transform.position, closestEnemy.position) > stoppingDistance)
        {
            rb.AddForce(transform.up * moveSpeed * 2);
        }
        //If the enemy is too close to the player but not close enough to retreat, the enemy gain nor lose velocity.
        else if (Vector2.Distance(transform.position, closestEnemy.position) < stoppingDistance && (Vector2.Distance(transform.position, closestEnemy.position) > retreatDistance))
        {
            transform.position = this.transform.position;
        }
        //If the enemy is too close to the player, the enemy will retreat.
        else if (Vector2.Distance(transform.position, closestEnemy.position) < retreatDistance)
        {
            rb.AddForce(transform.up * -moveSpeed);
        }
    }

    void Shooting()
    {
        if (timeBtwShots <= 0)
        {
            timeBtwShots = startTimeBtwShots;
            //Fires a bullet and starts a countdown
            Instantiate(projectile, firePoint.position, firePoint.rotation);
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
        
        //Looks at closest enemy.
        var addAngle = 270;
        var dir = closestEnemy.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + addAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
    }

    void FindClosestEnemy()
    {
        //Resets the closest enemy every frame to avoid bugs.
        distToClosestEnemy = Mathf.Infinity;
        closestEnemy = null;
        currentEnemies = spawnsc.enemies;
        foreach (Transform currentEnemies in spawnsc.enemies)
        {
            //Calculates the distance of each enemy.
            distanceToEnemy = (currentEnemies.transform.position - this.transform.position).sqrMagnitude;
            //If the distance is lower than the previous value, changes target to enemy with the closest distance.
            if (distanceToEnemy < distToClosestEnemy)
            {
                distToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemies;
            }
        }
    }
    void dead()
    {
        Destroy(gameObject);
    }
}
