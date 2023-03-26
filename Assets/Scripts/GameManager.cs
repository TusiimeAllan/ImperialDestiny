using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string _gameSceneName;
    public void PlayGame()
    {
        SceneManager.LoadScene(_gameSceneName);
    }
}
