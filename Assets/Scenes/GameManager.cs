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
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (player1 != null && player1.transform.position.y < fallThreshold)
        {
            GameOver("Player 1 fell!");
        }
        else if (player2 != null && player2.transform.position.y < fallThreshold)
        {
            GameOver("Player 2 fell!");
        }

        if (player1 == null || player2 == null)
        {
            GameOver("A player was lost!");
        }
    }

    void GameOver(string reason)
    {
        Debug.Log("Game Over! Reason: " + reason);

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        Time.timeScale = 0;
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadNextLevel()
    {
        if (currentLevelIndex + 1 < levels.Length)
        {
            currentLevelIndex++;
            SceneManager.LoadScene(levels[currentLevelIndex]);
        }
        else
        {
            Debug.Log("No more levels! Game Completed!");
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
