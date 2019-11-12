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
    public List<Transform> enemies = new List<Transform>(); 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount < 3)
        {
            spawnEnemies();
        }
        else
        {
            return;
        }

    }

    void spawnEnemies()
    {
        randEnemy = Random.Range(0, 2);
        randSpawn = Random.Range(0, spawner.Length);
        GameObject Clone = (GameObject)Instantiate(enemy[randEnemy], spawner[randSpawn].position, spawner[randSpawn].rotation);
        enemies.Add(Clone.GetComponent<Transform>());
        enemyCount++;
    }
}
