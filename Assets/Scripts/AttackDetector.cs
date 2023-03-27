using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetector : MonoBehaviour
{
    private Player _player;
    private Enemy _enemy;

    private void Start()
    {
        Transform parentTransform = gameObject.transform.parent;
        GameObject parentObject = parentTransform.gameObject;

        if (gameObject.CompareTag("Player"))
        {
            _player = parentObject.GetComponent<Player>();
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            _enemy = parentObject.GetComponent<Enemy>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if (other.CompareTag("Player") && gameObject.CompareTag("Enemy"))
        // {
        //     // Reduce health of enemy character
        //     int _damageAmount = other.GetComponent<PlayerAnimationListener>()._player.attackStrength;
        //     _enemy.healthSystem.Damage(_damageAmount);

        //     _enemy.UpdateHealth();
        //     Debug.Log("Player Detected");
        // }
        // else if (other.CompareTag("Enemy") && gameObject.CompareTag("Player"))
        // {
        //     // Reduce health of player character
        //     int _damageAmount = other.GetComponent<EnemyAnimationListener>()._enemy.attackStrength;
        //     _player.healthSystem.Damage(_damageAmount);

        //     Debug.Log("Enemy Detected");

        // }

        if (_enemy != null)
        {
            if (other.CompareTag("Player"))
            {
                int _damageAmount = other.GetComponent<PlayerAnimationListener>()._player.attackStrength;
                _enemy.healthSystem.Damage(_damageAmount);

                _enemy.UpdateHealth();

                Debug.Log("Player Detected");
            }
        }
        else if (_player != null)
        {
            if (other.CompareTag("Enemy"))
            {
                int _damageAmount = other.GetComponent<EnemyAnimationListener>()._enemy.attackStrength;
                _player.healthSystem.Damage(_damageAmount);

                _player.UpdateHealth();

                Debug.Log("Enemy Detected");
            }
        }


    }
}
