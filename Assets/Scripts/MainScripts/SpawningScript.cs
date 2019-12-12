using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    public Transform[] spawner;
    public GameObject[] enemy;
    public int enemyCount = 0;
    public int randEnemy;
    public int randSpawn;
    public float spawnTimer;
    private float spawnTime = 1f;
    public float enemyLimit;
    public float enemyScaling;
    public ScoreScript score;
    public List<Transform> enemies = new List<Transform>(); 
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("scoretext").GetComponent<ScoreScript>();
        enemyLimit = 1;
        spawnTimer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {

        difficultyCurve();
        //If there are not enough enemies spawns a new one after a delay
        if (enemyCount < enemyLimit)
        {
            if (spawnTimer <= 0)
            {
                spawnEnemies();
                spawnTimer = spawnTime;
            }
            else
            {
                //Timer for how fast it shoots
                spawnTimer -= Time.deltaTime;
            }
        }
    }
    private void FixedUpdate()
    {
        if (enemyScaling > enemyLimit)
        {
            enemyLimit = enemyScaling;
        }
    }

    void spawnEnemies()
    {
        randEnemy = Random.Range(0, 11);
        randSpawn = Random.Range(0, spawner.Length);
        if(randEnemy < 8)
        {
            GameObject Clone = (GameObject)Instantiate(enemy[0], spawner[randSpawn].position, spawner[randSpawn].rotation);
            enemies.Add(Clone.GetComponent<Transform>());
        }
        else
        {
            GameObject Clone = (GameObject)Instantiate(enemy[1], spawner[randSpawn].position, spawner[randSpawn].rotation);
            enemies.Add(Clone.GetComponent<Transform>());
        }
        enemyCount++;
    }

    void difficultyCurve()
    {
        enemyScaling = score.scoreOfPlayer;
        if(enemyCount < 4)
        {
            Mathf.Round(enemyScaling /= 5);
            enemyScaling = (int)(enemyScaling);
        }
        else
        {
            Mathf.Round(enemyScaling /= 10);
            enemyScaling = (int)(enemyScaling);
        }
        //when the player reaches a killcount milestone, decreases the time between enemy spawn
        if(enemyLimit >= 3)
        {
            spawnTime = 0.9f;
        }
        if(enemyLimit >= 10)
        {
            spawnTime = 0.5f;
        }
        if(enemyLimit >= 100)
        {
            spawnTime = 0.1f;
        }
        if(enemyLimit >= 1000)
        {
            spawnTime = 0;
        }

    }
}
