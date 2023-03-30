using UnityEngine;
using TMPro;

public class PostCombat : MonoBehaviour
{
    [Space]
    [Header("Post Combat UI Objects")]
    [SerializeField] private GameObject postCombatUI;
    [SerializeField] private GameObject winnerBadge;
    [SerializeField] private TextMeshProUGUI winnerExperienceText;
    [SerializeField] private GameObject looserBadge;
    [SerializeField] private TextMeshProUGUI looserExperienceText;

    private void Start()
    {
        postCombatUI.SetActive(false);
    }

    public void YouWin()
    {
        postCombatUI.SetActive(true);
        winnerBadge.SetActive(true);
        winnerExperienceText.text = "500 XP";
    }

    public void YouLoose()
    {
        postCombatUI.SetActive(true);
        looserBadge.SetActive(true);
        winnerExperienceText.text = "10 XP";
    }
}
