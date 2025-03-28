using UnityEngine;

public class player_atacar : MonoBehaviour
{
    public Transform attackPoint; // Ponto de origem do ataque
    public float attackRange = 1f; // Alcance do ataque
    public int attackDamage = 20; // Dano do ataque
    public LayerMask enemyLayer; // Camada dos inimigos

    void Update()
    {
        // Detecta o comando de ataque
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Detecta inimigos dentro do alcance do ataque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            // Verifica se o colisor ainda é válido
            if (enemy != null)
            {
                EnemyAttack enemyScript = enemy.GetComponent<EnemyAttack>();
                if (enemyScript != null)
                {
                    enemyScript.TakeDamage(attackDamage); // Aplica dano
                    Debug.Log("Inimigo atingido! Dano causado: " + attackDamage);
                }
                else
                {
                    Debug.LogWarning("Nenhum script EnemyAttack encontrado no inimigo!");
                }
            }
            else
            {
                Debug.LogWarning("Um inimigo foi destruído antes de aplicar dano.");
            }
        }
    }

    // Desenha o alcance do ataque no editor para visualização
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

