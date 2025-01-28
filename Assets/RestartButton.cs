using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void Restart()
    {

        
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene("Level1");
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene("Level2");
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            SceneManager.LoadScene("Level3");
        }
    }
}


