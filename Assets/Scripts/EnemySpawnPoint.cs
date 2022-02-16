using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnDelay = 1f;
    private float nextSpawnIn;
    private int enemiesLeftToSpawn;
    public int enemiesInWave = 10;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnIn = spawnDelay;
        enemiesLeftToSpawn = 0;
        foreach(GameObject waypoint in waypoints)
        {
            waypoint.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesLeftToSpawn > 0)
        {
            nextSpawnIn -= Time.deltaTime;
            if (nextSpawnIn <= 0)
            {
                nextSpawnIn = spawnDelay;
                GameObject enemy = Instantiate(enemyPrefab, transform.position , Quaternion.identity);
                enemy.GetComponent<EnemyMovement>().waypoints = waypoints;
                GameRound.GetInstance().AddEnemy(enemy);
                enemiesLeftToSpawn--;
            }
        }
        if (Input.GetKeyDown("p") && enemiesLeftToSpawn <= 0)
        {
            enemiesLeftToSpawn = enemiesInWave;
            nextSpawnIn = 0;
        }
    }
}
