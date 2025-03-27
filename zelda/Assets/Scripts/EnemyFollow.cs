using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    private void Update()
    {
        if (player != null) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}

