using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab do inimigo a ser instanciado
    public Transform[] spawnPoints; // Array de pontos de spawn
    public int maxEnemies = 20; // Quantidade m�xima de inimigos permitidos
    public float spawnInterval = 1f; // Intervalo entre os spawns em segundos

    private int currentEnemyCount = 0; // Contador de inimigos na cena

    private void Start()
    {
        // Verifica se h� pelo menos 5 pontos de spawn configurados
        if (spawnPoints.Length < 5)
        {
            Debug.LogError("� necess�rio configurar pelo menos 5 pontos de spawn no array de spawnPoints!");
            return;
        }

        // Inicia o ciclo de spawn
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        // Verifica se j� h� o n�mero m�ximo de inimigos na cena
        if (currentEnemyCount >= maxEnemies) return;

        // Seleciona um ponto de spawn aleat�rio
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instancia o inimigo no ponto de spawn selecionado
        Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);

        // Incrementa o contador de inimigos
        currentEnemyCount++;
    }

    public void EnemyDestroyed()
    {
        // M�todo para ser chamado quando um inimigo � destru�do
        if (currentEnemyCount > 0)
        {
            currentEnemyCount--;
        }
    }
}


