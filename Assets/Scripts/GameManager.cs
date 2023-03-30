using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player[] playerData;
    public Enemy[] enemyData;

    [SerializeField] private int currentPlayerIndex = 0;
    [SerializeField] private int currentEnemyIndex = 0;
    [SerializeField] private bool playerSelected = false;

    public bool enemyTurn = false;

    public AudioSource VictorySound;
    public AudioSource DefeatSound;
    public AudioSource AttackSound;
    public AudioSource HealSound;
    public AudioSource BGMusicSound;

    private bool gameOver = false;

    [Space]
    [Header("Post Combat")]
    [SerializeField] private PostCombat postCombat;


    private void Start()
    {
        postCombat = gameObject.GetComponent<PostCombat>();
        playerData[currentPlayerIndex].selected = true;
    }

    private void Update()
    {
        if (!playerSelected && !gameOver)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Unselect the previous player
                playerData[currentPlayerIndex].selected = false;

                // Toggle to the next player
                currentPlayerIndex = (currentPlayerIndex + 1) % playerData.Length;

                // Select the current player
                playerData[currentPlayerIndex].selected = true;

            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Unselect the previous player
                playerData[currentPlayerIndex].selected = false;

                // Toggle to the previous player
                currentPlayerIndex = (currentPlayerIndex - 1 + playerData.Length) % playerData.Length;

                // Select the current player
                playerData[currentPlayerIndex].selected = true;

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerSelected = true;
            }
        }
        else
        {
            enemyData[currentEnemyIndex].selected = true;

            // Toggle between the enemies
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Unselect the previous enemy
                enemyData[currentEnemyIndex].selected = false;

                // Toggle to the next enemy
                currentEnemyIndex = (currentEnemyIndex + 1) % enemyData.Length;

                // Select the current player
                enemyData[currentEnemyIndex].selected = true;

            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Unselect the previous player
                enemyData[currentEnemyIndex].selected = false;

                // Toggle to the previous player
                currentEnemyIndex = (currentEnemyIndex - 1 + enemyData.Length) % enemyData.Length;

                // Select the current player
                enemyData[currentEnemyIndex].selected = true;

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerAttack();
            }
        }


        if (enemyTurn && !gameOver)
        {
            EnemyAttack();
        }

    }

    private void PlayerAttack()
    {
        Animator playerAnimator = playerData[currentPlayerIndex].character.GetComponent<Animator>();

        GameObject enemy = enemyData[currentEnemyIndex].face.gameObject;

        playerData[currentPlayerIndex].playerData.PlayAttack(playerAnimator);

        Vector3 targetPosition = enemy.transform.position;

        // Move Towards Target
        playerData[currentPlayerIndex].character.transform.localPosition = targetPosition;

        AttackSound.Play();

        resetSelection();
    }

    private void EnemyAttack()
    {
        enemyTurn = false;

        int randomEnemyIndex = selectAttackingEnemy();
        Animator enemyAnimator = enemyData[randomEnemyIndex].character.GetComponent<Animator>();

        int randomTargetIndex = selectPlayerToAttack();
        GameObject player = playerData[randomTargetIndex].face.gameObject;

        currentEnemyIndex = randomEnemyIndex;

        enemyData[currentEnemyIndex].enemyData.PlayAttack(enemyAnimator);

        Vector3 targetPosition = player.transform.position;

        // Move Towards Target
        enemyData[currentEnemyIndex].character.transform.localPosition = targetPosition;

        AttackSound.Play();

        resetSelection();

        CheckForWinner();
    }

    private int selectAttackingEnemy()
    {
        int index = Random.Range(0, enemyData.Length);

        while (enemyData[index].getEnemyHealth() <= 0)
        {
            index = Random.Range(0, enemyData.Length);
        }

        return index;
    }

    private int selectPlayerToAttack()
    {
        int index = Random.Range(0, playerData.Length);

        while (playerData[index].getPlayerHealth() <= 0)
        {
            index = Random.Range(0, playerData.Length);
        }

        return index;
    }

    private void resetSelection()
    {
        enemyData[currentEnemyIndex].selected = false;
        playerSelected = false;
    }

    public void resetFightingStanza(bool player)
    {
        if (player)
        {
            playerData[currentPlayerIndex].character.transform.position = playerData[currentPlayerIndex].gameObject.transform.position;
        }
        else
        {
            enemyData[currentEnemyIndex].character.transform.position = enemyData[currentEnemyIndex].gameObject.transform.position;
        }

    }

    public void CheckForWinner()
    {
        bool playersAlive = false;
        bool enemiesAlive = false;

        // Check if any players are still alive
        foreach (Player player in playerData)
        {
            if (player.getPlayerHealth() > 0)
            {
                playersAlive = true;
                break;
            }
        }

        // Check if any enemies are still alive
        foreach (Enemy enemy in enemyData)
        {
            if (enemy.getEnemyHealth() > 0)
            {
                enemiesAlive = true;
                break;
            }
        }

        if (playersAlive && !enemiesAlive)
        {
            // You win
            gameOver = true;

            postCombat.YouWin();

            BGMusicSound.mute = true;
            VictorySound.Play();
        }
        else if (!playersAlive && enemiesAlive)
        {
            // Enemies win
            gameOver = true;

            postCombat.YouLoose();

            BGMusicSound.mute = true;
            DefeatSound.Play();
        }
    }
}
