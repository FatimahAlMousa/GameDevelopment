using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
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

        if (player1 == null || player2 == null)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        LoadGameOverScene();
    }

    public void LoadGameOverScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Lose");
    }

    

}
