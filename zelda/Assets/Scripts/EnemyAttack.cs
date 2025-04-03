using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 1.5f;  
    public float attackCooldown = 1f; 
    public int attackDamage = 10;     
    public int maxHealth = 50;        

    private float lastAttackTime = 0f; 
    private int currentHealth;        
    private Transform player;         

    void Start()
    {
        currentHealth = maxHealth; 
        FindPlayer();

        if (player == null)
        {
            
            InvokeRepeating(nameof(FindPlayer), 0, 1f); 
            enabled = false;
        }
    }

    void FindPlayer()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            CancelInvoke(nameof(FindPlayer));
            enabled = true;
            
        }
    }

    void Update()
    {
        if (player == null) return;

        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    void Attack()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, attackRange, LayerMask.GetMask("Player"));

        if (hit != null)
        {
            PlayerHealth playerHealth = hit.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}