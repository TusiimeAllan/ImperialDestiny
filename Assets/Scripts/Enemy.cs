using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    public GameObject characterPrefab;

    private int currentHealth;

    private void Start()
    {
        currentHealth = enemyData.maxHealth;

        Instantiate(characterPrefab, transform.position, transform.rotation);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
