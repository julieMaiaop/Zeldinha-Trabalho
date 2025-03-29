using UnityEngine;

public class player_atacar : MonoBehaviour
{
    public Transform attackPoint; // Ponto de origem do ataque
    public float attackRange = 1f; // Alcance do ataque
    public int attackDamage = 20; // Dano do ataque
    public LayerMask enemyLayer; // Camada dos inimigos
    public Animator playerAnimator; // Refer�ncia para o Animator
    public string attackAnimationName = "Attack"; // Nome da anima��o de ataque

    void Update()
    {
        // Detecta o clique do bot�o esquerdo do mouse
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Ativa a anima��o de ataque
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger(attackAnimationName);
        }
        else
        {
            Debug.LogWarning("Animator n�o encontrado no jogador!");
        }

        // Detecta inimigos dentro do alcance do ataque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            // Verifica se o colisor ainda � v�lido
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
                Debug.LogWarning("Um inimigo foi destru�do antes de aplicar dano.");
            }
        }
    }

    // Desenha o alcance do ataque no editor para visualiza��o
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}