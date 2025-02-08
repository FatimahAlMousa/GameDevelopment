using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject win;
    public GameObject lose;

    public GameObject player1;
    public GameObject player2;
    public float fallThreshold = -10f;

    private bool player1ReachedFence = false;
    private bool player2ReachedFence = false;

    void Start()
    {
        if (player1 == null || player2 == null)
        {
            Debug.LogError("One or more required GameObjects are not assigned in the GameManager.");
            return;
        }

        player1ReachedFence = false;
        player2ReachedFence = false;
        Debug.Log("GameManager started. States reset.");
    }

    void Update()
    {
        if (player1 != null && player1.transform.position.y < fallThreshold)
        {
            GameOver();
        }
        else if (player2 != null && player2.transform.position.y < fallThreshold)
        {
            GameOver();
        }
    }

    // Make GameOver() public so other scripts can call it
    public void GameOver()
    {
        Debug.Log("Game Over!");
        LoadGameOverScene();
    }

    public void LoadGameOverScene()
    {
        Time.timeScale = 1;
        lose.SetActive(true);
    }

    public void PlayerReachedWinArea(GameObject player)
    {
        if (player == player1)
        {
            player1ReachedFence = true;
            Debug.Log("Player 1 reached the win area.");
        }
        else if (player == player2)
        {
            player2ReachedFence = true;
            Debug.Log("Player 2 reached the win area.");
        }

        // Check if both players have reached the win area
        if (player1ReachedFence && player2ReachedFence)
        {
            Win();
        }
    }

    void Win()
    {
        Debug.Log("You Win!");
        LoadWinScene();
    }

    public void LoadWinScene()
    {
        Time.timeScale = 1;
        win.SetActive(true);
    }
}