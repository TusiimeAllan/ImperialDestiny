using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Characters/Enemy")]
public class EnemyData : CharacterData
{
    public int attackStrength = 10;

    public AnimationClip idleAnimation;
    public AnimationClip attackAnimation;
    public AnimationClip victoryAnimation;
    public AnimationClip deathAnimation;
}