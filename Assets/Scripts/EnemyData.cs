using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Characters/Enemy")]
public class EnemyData : CharacterData
{
    public int attackStrength = 10;
    public int healAmount = 5;

    public AnimationClip idleAnimation;
    public AnimationClip attackAnimation;
    public AnimationClip victoryAnimation;
    public AnimationClip deathAnimation;

    public void PlayIdle(Animator _animator)
    {
        _animator.Play(idleAnimation.name);
    }

    public void PlayAttack(Animator _animator)
    {
        _animator.Play(attackAnimation.name);
    }

    public void PlayVictory(Animator _animator)
    {
        _animator.Play(victoryAnimation.name);
    }

    public void PlayDead(Animator _animator)
    {
        _animator.Play(deathAnimation.name);
    }
}