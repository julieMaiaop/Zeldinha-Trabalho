using UnityEngine;

public class player_atacar : MonoBehaviour
{
    [Header("Ataque")]
    public Transform attackPoint;
    public float attackRange = 1f;
    public int attackDamage = 20;
    public LayerMask enemyLayer;
    public float attackCooldown = 0.5f;

    [Header("Movimento")]
    public float moveSpeed = 5f;
    public float acceleration = 10f;

    [Header("Esquiva")]
    public float dodgeSpeed = 15f;
    public float dodgeDuration = 0.3f;
    public float dodgeCooldown = 1f;
    public KeyCode dodgeKey = KeyCode.LeftShift;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isDodging = false;
    private float nextAttackTime = 0f;
    private float dodgeEndTime;
    private float nextDodgeTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimento
        moveInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        // Esquiva
        if (Input.GetKeyDown(dodgeKey) && !isDodging && Time.time >= nextDodgeTime && moveInput != Vector2.zero)
        {
            StartDodge();
        }

        // Ataque (botão esquerdo do mouse)
        if (Input.GetMouseButtonDown(0) && Time.time >= nextAttackTime && !isDodging)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void FixedUpdate()
    {
        if (isDodging)
        {
            rb.velocity = moveInput * dodgeSpeed;
            if (Time.time >= dodgeEndTime)
            {
                isDodging = false;
            }
        }
        else
        {
            Vector2 targetVelocity = moveInput * moveSpeed;
            rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, acceleration * Time.fixedDeltaTime);
        }
    }

    void StartDodge()
    {
        isDodging = true;
        dodgeEndTime = Time.time + dodgeDuration;
        nextDodgeTime = Time.time + dodgeDuration + dodgeCooldown;
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy != null)
            {
                EnemyAttack enemyScript = enemy.GetComponent<EnemyAttack>();
                if (enemyScript != null)
                {
                    enemyScript.TakeDamage(attackDamage);
                    Debug.Log("Dano causado: " + attackDamage);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}