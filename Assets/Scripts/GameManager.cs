using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player[] playerData;
    public Enemy[] enemyData;

    [SerializeField] private int currentPlayerIndex = 0;
    [SerializeField] private int currentEnemyIndex = 0;
    [SerializeField] private bool playerSelected = false;

    private bool attackDone = false;

    public AudioSource VictorySound;
    public AudioSource DefeatSound;
    public AudioSource AttackSound;
    public AudioSource HealSound;

    private void Start()
    {
        playerData[currentPlayerIndex].selected = true;
    }

    private void Update()
    {
        if (!playerSelected)
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

    private void resetSelection()
    {
        enemyData[currentEnemyIndex].selected = false;
        playerSelected = false;
    }

    public void resetFightingStanza()
    {
        playerData[currentPlayerIndex].character.transform.position = playerData[currentPlayerIndex].gameObject.transform.position;
        attackDone = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("BattleGround");
    }
}
