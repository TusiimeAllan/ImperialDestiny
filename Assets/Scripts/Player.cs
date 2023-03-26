using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthSystem healthSystem;
    public PlayerData playerData;
    public GameObject characterPrefab;
    [SerializeField] private Animator characterAnimator;
    [HideInInspector] public GameObject character;

    [SerializeField] private int currentHealth;
    public bool selected = false;
    public GameObject selectionSprite;
    public GameObject face; // Where the Enemy will stand while fighting

    private void Start()
    {
        HealthSystem _healthSystem = new HealthSystem(100);
        healthSystem = _healthSystem;

        characterAnimator = characterPrefab.GetComponent<Animator>();
        currentHealth = healthSystem.GetHealth();

        GameObject instantiatedPlayer = Instantiate(characterPrefab, transform.position, transform.rotation);
        character = instantiatedPlayer;

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
        playerData.PlayDead(characterAnimator);
    }
}
