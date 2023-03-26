using UnityEngine;

[CreateAssetMenu(fileName = "New ImperialDestiny Character", menuName = "Characters/Character")]
public class CharacterData : ScriptableObject
{
    public int health;
    public int experienceGiven = 10;
    public bool alive = true;

}