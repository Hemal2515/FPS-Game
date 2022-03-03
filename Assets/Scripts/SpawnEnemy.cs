using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int enemyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCount < 2)
        {
            Vector3 SpawnPosition = new Vector3(Random.Range(275,320), 12, Random.Range(420,470));
            Instantiate(EnemyPrefab, SpawnPosition, Quaternion.identity);
            enemyCount++;
        }
    }
}
