using System.Collections;
using UnityEngine;

public class EnemyAnimationListener : MonoBehaviour
{
    private Animator _animator;
    public EnemyData _enemy;
    private GameManager _gameManager;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public void ResumeIdle()
    {
        StartCoroutine(_resumeIdle());
    }

    IEnumerator _resumeIdle()
    {
        yield return new WaitForSeconds(0.5f);
        _gameManager.resetFightingStanza(false);
        _enemy.PlayIdle(_animator);

        _gameManager.enemyTurn = false;

        _gameManager.CheckForWinner();
    }
}
