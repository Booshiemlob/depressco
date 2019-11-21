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
    public float enemyLimit;
    public float enemyScaling;
    public ScoreScript score;
    public List<Transform> enemies = new List<Transform>(); 
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("scoretext").GetComponent<ScoreScript>();
        enemyLimit = 1;
    }

    // Update is called once per frame
    void Update()
    {

        difficultyCurve();

        if (enemyCount < enemyLimit)
        {
            spawnEnemies();
        }
        else
        {
            return;
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



    }
}
