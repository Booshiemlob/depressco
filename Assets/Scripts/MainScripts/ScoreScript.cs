using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int scoreOfPlayer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text="Score:" + scoreOfPlayer;
    }

    public void UpScore()
    {
        scoreOfPlayer = scoreOfPlayer + 1;
    }
}
