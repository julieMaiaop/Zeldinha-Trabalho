using UnityEngine;

public class smoke_dano : MonoBehaviour
{
    public float damageInterval = 2f; 
    public int damageAmount = 40;     
    private float nextDamageTime;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
           
            other.GetComponent<EnemyAttack>()?.TakeDamage(damageAmount);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && Time.time >= nextDamageTime)
        {
           
            other.GetComponent<EnemyAttack>()?.TakeDamage(damageAmount);
            nextDamageTime = Time.time + damageInterval;
        }
    }
}