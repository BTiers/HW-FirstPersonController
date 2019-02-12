using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Rigidbody enemy;
    public float spawnFrequency = 2f;
    private float latestSpawn = 0f;


    private bool ShouldSpawn()
    {
        latestSpawn += Time.deltaTime;
        return latestSpawn >= spawnFrequency;
    }
    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn())
        {
            Rigidbody enemyClone = (Rigidbody)Instantiate(enemy, transform.position, transform.rotation);
            latestSpawn = 0f;
        }
    }
}
