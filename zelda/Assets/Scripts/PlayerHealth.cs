using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    
    public int healAmount = 25;
    public int healthPotions = 3;


    public TMP_Text healthText;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            UseHealthPotion();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UseHealthPotion()
    {
        if (healthPotions > 0 && currentHealth < maxHealth)
        {
            currentHealth += healAmount;
            healthPotions--;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            UpdateHealthUI(); 
        }
    }

    void UpdateHealthUI()
    {
        
        if (healthText != null)
        {
            healthText.text = $"Vida: {currentHealth}/{maxHealth}\nPoções: {healthPotions}";
        }
    }

    public void AddHealthPotion(int amount)
    {
        healthPotions += amount;
        UpdateHealthUI(); 
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}