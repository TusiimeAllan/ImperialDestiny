using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private GameManager _gameManager;
    public HealthSystem healthSystem;
    public PlayerData playerData;
    public GameObject characterPrefab;
    [SerializeField] private Animator characterAnimator;

    // [HideInInspector] 
    public GameObject character;

    [SerializeField] private int currentHealth;
    public bool selected = false;
    public GameObject selectionSprite;
    public GameObject face; // Where the Enemy will stand while fighting

    [Space]
    [Header("Life Bar")]
    public GameObject lifeContainer;
    public TextMeshProUGUI lifeText;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        HealthSystem _healthSystem = new HealthSystem(100);
        healthSystem = _healthSystem;

        currentHealth = healthSystem.GetHealth();

        GameObject instantiatedPlayer = Instantiate(characterPrefab, transform.position, transform.rotation);
        character = instantiatedPlayer;

        characterAnimator = character.GetComponent<Animator>();

        lifeText.text = currentHealth.ToString();
        float healthPercent = Mathf.Clamp(healthSystem.GetHealthPercent(), 0f, 1f);
        lifeContainer.transform.localScale = new Vector3(healthPercent, lifeContainer.transform.localScale.y, lifeContainer.transform.localScale.z);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && selected)
        {
            healthSystem.Heal(playerData.healAmount);
            UpdateHealth();

            _gameManager.HealSound.Play();
        }

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

    public void UpdateHealth()
    {
        currentHealth = healthSystem.GetHealth();

        lifeText.text = currentHealth.ToString();
        float healthPercent = Mathf.Clamp(healthSystem.GetHealthPercent(), 0f, 1f);
        lifeContainer.transform.localScale = new Vector3(healthPercent, lifeContainer.transform.localScale.y, lifeContainer.transform.localScale.z);

    }

    private void Die()
    {
        playerData.PlayDead(characterAnimator);
    }
}
