using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_Menu : MonoBehaviour
{

    public Button myButton;
    void OnEnable()
    {
        //Detects if a button is pressed and runs Start.
        myButton.onClick.AddListener(Start);

    }
    void Start()
    {
        SceneManager.LoadScene("Game");
    }
}
