using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject characterPrefab;

    private int currentHealth;

    private void Start()
    {
        currentHealth = playerData.maxHealth;

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
