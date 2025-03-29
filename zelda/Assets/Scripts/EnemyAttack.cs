using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 1.5f;  // Distância do ataque
    public float attackCooldown = 1f; // Tempo de recarga entre os ataques
    public int attackDamage = 10;     // Dano do ataque
    public int maxHealth = 50;        // Vida máxima do inimigo

    private float lastAttackTime = 0f; // Tempo do último ataque
    private int currentHealth;        // Vida atual
    private Transform player;         // Referência para o jogador

    void Start()
    {
        currentHealth = maxHealth; // Inicializa a vida do inimigo
        FindPlayer();

        if (player == null)
        {
            Debug.LogWarning("Jogador não encontrado inicialmente, tentando novamente...");
            InvokeRepeating(nameof(FindPlayer), 0, 1f); // Tenta a cada 1 segundo
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
            Debug.Log("Jogador encontrado com sucesso!");
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
            Debug.Log("Jogador atingido!");
            PlayerHealth playerHealth = hit.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
                Debug.Log("Dano aplicado ao jogador: " + attackDamage);
            }
            else
            {
                Debug.LogWarning("Componente PlayerHealth não encontrado no jogador!");
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
        Debug.Log("Inimigo morreu!");
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}