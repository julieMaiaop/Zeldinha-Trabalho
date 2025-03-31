using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform playerTarget; 
    public float speed2 = 2f; 
    public float maxDistance = 10f;

    private Vector2 spawnPoint;

    private void Start()
    {
      
        spawnPoint = transform.position;
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;

      
        if (playerTarget == null)
        {
            Debug.LogError("Nenhum GameObject com a tag 'Player' foi encontrado!");
        }
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
            
            transform.position = Vector2.MoveTowards(transform.position, spawnPoint, speed2 * Time.deltaTime);
           
        }
    }
}

