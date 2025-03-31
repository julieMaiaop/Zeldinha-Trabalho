using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints; 
    public int maxEnemies = 20; 
    public float spawnInterval = 1f;

    private int currentEnemyCount = 0;

    private void Start()
    {
        
        if (spawnPoints.Length < 5)
        {
            return;
        }

    
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    private void SpawnEnemy()
    {
            
        if (currentEnemyCount >= maxEnemies) return;

        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

       
        Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);

        
        currentEnemyCount++;
    }

    public void EnemyDestroyed()
    {
        if (currentEnemyCount > 0)
        {
            currentEnemyCount--;
        }
    }
}


