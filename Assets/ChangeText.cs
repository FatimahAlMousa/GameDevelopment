using System.Collections;
using System.Collections.Generic;
using TMPro; 
using UnityEngine;
using UnityEngine.UI; 

public class ChangeText : MonoBehaviour
{
    public Button myButton; 

    void Start()
    {
        if (myButton != null)
        {
            
            TextMeshProUGUI buttonText = myButton.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.text = "Start Game"; 
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component is missing from the button.");
            }
        }
        else
        {
            Debug.LogError("Button is not assigned in the Inspector.");
        }
    }
}
