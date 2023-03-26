using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthSystem healthSystem;
    public EnemyData enemyData;
    public GameObject characterPrefab;
    private Animator characterAnimator;

    private int currentHealth;
    [HideInInspector] public GameObject character;

    public bool turnReached = false;
    public bool selected = false;
    public GameObject selectionSprite;
    public GameObject face; // Where the Player will stand while fighting

    private void Start()
    {
        HealthSystem _healthSystem = new HealthSystem(100);
        healthSystem = _healthSystem;

        characterAnimator = characterPrefab.GetComponent<Animator>();
        currentHealth = healthSystem.GetHealth();

        GameObject instantiatedEnemy = Instantiate(characterPrefab, transform.position, transform.rotation);
        character = instantiatedEnemy;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }

        if (selected)
        {
            selectionSprite.SetActive(true);
        }
        else
        {
            selectionSprite.SetActive(false);
        }
    }

    private void Die()
    {
        enemyData.PlayDead(characterAnimator);
    }
}
