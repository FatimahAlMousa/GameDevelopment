using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float fallThreshold = -10f;
    public GameObject gameOverUI;
    public string[] levels;
    private int currentLevelIndex = 0;

    void Start()
    {
        if (player1 == null || player2 == null || gameOverUI == null)
        {
            Debug.LogError("Missing required GameObjects in GameManager.");
            return;
        }

        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
    }

    void Update()
    {
        if ((player1 != null && player1.transform.position.y < fallThreshold) ||
            (player2 != null && player2.transform.position.y < fallThreshold))
        {
            GameOver();
        }

        if (player1 == null || player2 == null)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
        Time.timeScale = 0;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        if (currentLevelIndex + 1 < levels.Length)
        {
            currentLevelIndex++;
            Time.timeScale = 1;
            SceneManager.LoadScene(levels[currentLevelIndex]);
        }
        else
        {
            Debug.Log("No more levels! Game Completed!");
        }
    }
}
