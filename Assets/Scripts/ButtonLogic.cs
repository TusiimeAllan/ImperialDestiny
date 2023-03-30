using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLogic : MonoBehaviour
{
    [SerializeField] private string battleSceneName;
    [SerializeField] private string homeSceneName;

    public void PlayGame()
    {
        SceneManager.LoadScene(battleSceneName);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoHome()
    {
        SceneManager.LoadScene(homeSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
