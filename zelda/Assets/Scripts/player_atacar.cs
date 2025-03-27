using UnityEngine;

public class playeratacar : MonoBehaviour
{
    public Transform attackPoint; 
    public float attackRange = 1f; 
    public int attackDamage = 20; 
    public LayerMask enemyLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyAttack>().TakeDamage(attackDamage); 
            Debug.Log("Inimigo atingido!");
        }
    }

   
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

