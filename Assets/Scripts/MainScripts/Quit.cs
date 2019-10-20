using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public Button myButton;
    void OnEnable()
    {
        //Detects if a button is pressed and runs Exit.
        myButton.onClick.AddListener(Exit);
    }
    void Exit()
    {
        Application.Quit();
    }
}
