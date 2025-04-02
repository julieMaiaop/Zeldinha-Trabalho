using UnityEngine;

public class fumaça_smoke : MonoBehaviour
{
    public float throwForce = 10f;
    public float smokeDuration = 5f;
    public float smokeRadius = 3f;
    public GameObject smokeEffectPrefab;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * throwForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }

    void Explode()
    {
   
        GameObject smoke = Instantiate(smokeEffectPrefab, transform.position, Quaternion.identity);
        Destroy(smoke, smokeDuration);

       
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, smokeRadius);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                EnemyFollow enemyScript = enemy.GetComponent<EnemyFollow>();
                if (enemyScript != null)
                {
                    enemyScript.Stun(smokeDuration); 
                }
            }
        }

        Destroy(gameObject); 
    }

    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, smokeRadius);
    }
}