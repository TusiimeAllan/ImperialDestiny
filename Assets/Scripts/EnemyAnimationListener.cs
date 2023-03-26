using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationListener : MonoBehaviour
{
    private Animator _animator;
    public EnemyData _enemy;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ResumeIdle()
    {
        StartCoroutine(_resumeIdle());
    }

    IEnumerator _resumeIdle()
    {
        yield return new WaitForSeconds(1.0f);
        _enemy.PlayIdle(_animator);
    }
}
