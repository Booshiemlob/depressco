using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    public GameObject enemy;
    public int enemyCount = 0;
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
        Instantiate(enemy);
        enemyCount++;
        Debug.Log(enemyCount);
    }
}
