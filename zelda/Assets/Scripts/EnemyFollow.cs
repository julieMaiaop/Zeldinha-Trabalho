using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform playerTarget;
    public float speed2 = 2f;
    public float maxDistance = 10f;
    private Vector2 spawnPoint;

    private bool isStunned = false;
    private float stunTimer = 0f;
    private Vector2 randomDirection;

    private void Start()
    {
        spawnPoint = transform.position;
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (isStunned)
        {
           
            stunTimer -= Time.deltaTime;
            if (stunTimer <= 0f)
            {
                isStunned = false;
            }
            else
            {
                transform.Translate(randomDirection * speed2 * 0.3f * Time.deltaTime);
                return; 
            }
        }

       
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

    
    public void Stun(float duration)
    {
        if (!isStunned)
        {
            isStunned = true;
            stunTimer = duration;
            randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized; 
        }
    }
}