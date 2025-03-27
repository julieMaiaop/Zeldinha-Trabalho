using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform playerTarget; // Nova variável para evitar conflito
    public float speed2 = 2f;
    public float maxDistance = 10f;

    private Vector2 spawnPoint;

    private void Start()
    {
        spawnPoint = transform.position;
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform; // Encontra o jogador
    }

    private void Update()
    {
        if (playerTarget == null) return;

        float distanceFromSpawn = Vector2.Distance(transform.position, spawnPoint);

        if (distanceFromSpawn < maxDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, speed2 * Time.deltaTime);
        }
        else
        {
            Debug.Log("Inimigo atingiu a distância máxima e parou.");
        }
    }
}

