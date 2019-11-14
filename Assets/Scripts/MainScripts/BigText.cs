using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigText : MonoBehaviour
{
    //public int finalScore;
    // Start is called before the first frame update

    public GameObject player;
    public ScoreScript score;
    void Start()
    {
        
        player = GameObject.Find("player");
        score = GameObject.Find("scoretext").GetComponent<ScoreScript>();
        gameObject.SetActive(false);
    }

    //This displays the final score in big text 
    void Update()
    {
        gameObject.SetActive(true);
        Debug.Log("finalscore is displayed " + gameObject.activeSelf);
        this.GetComponent<Text>().text = "   Score:" + score.scoreOfPlayer + "\r\nGame Over";
    }
   
}
