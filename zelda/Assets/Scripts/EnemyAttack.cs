using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 1.5f;  // Distância do ataque
    public float attackCooldown = 1f; // Tempo de recarga entre os ataques
    public int attackDamage = 10;     // Dano do ataque
    public int maxHealth = 50;        // Vida máxima do inimigo

    private float lastAttackTime = 0f; // Tempo do último ataque
    private int currentHealth;        // Vida atual

    public Transform player; // Referência para o jogador

    void Start()
    {
        currentHealth = maxHealth; // Inicializa a vida do inimigo
    }

    void Update()
    {
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
        // Verifique se o jogador está dentro do alcance e aplique dano
        Collider2D hit = Physics2D.OverlapCircle(transform.position, attackRange, LayerMask.GetMask("Player"));

        if (hit != null)
        {
            // Aplica dano ao jogador
            PlayerHealth playerHealth = hit.GetComponent<PlayerHealth>(); // Pegando o script PlayerHealth do jogador

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage); // Aplica o dano
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
        // A lógica para a morte do inimigo
        Debug.Log("Inimigo morreu!");
        Destroy(gameObject); // Destroi o objeto inimigo
    }

    // Opcional: visualizar a área de ataque no editor para debug
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

