using System.Collections;
using UnityEngine;

public class PlayerAnimationListener : MonoBehaviour
{
    private Animator _animator;
    public PlayerData _player;
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
        _gameManager.resetFightingStanza(true);
        _player.PlayIdle(_animator);

        _gameManager.enemyTurn = true;

        _gameManager.CheckForWinner();
    }
}
