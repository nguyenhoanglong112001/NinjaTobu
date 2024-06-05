using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    private GameObject enemySpawn;
    [SerializeField] private int r;
    [SerializeField] private Transform spawnpoint;
    private bool isspawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        if (enemySpawn == null && !isspawn)
        {
            r = Random.Range(0, enemy.Length);
            enemySpawn = Instantiate(enemy[r], spawnpoint.position, Quaternion.identity);
            isspawn = true;
        }
    }
}
