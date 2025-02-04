using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartPlay : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1"); 
    }
}
