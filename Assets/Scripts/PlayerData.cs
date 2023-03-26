using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Characters/Player")]
public class PlayerData : CharacterData
{
    public int attackStrength = 10;

    public AnimationClip idleAnimation;
    public AnimationClip attackAnimation;
    public AnimationClip victoryAnimation;
    public AnimationClip deathAnimation;
}