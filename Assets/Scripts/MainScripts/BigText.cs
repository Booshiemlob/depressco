using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigText : MonoBehaviour
{
    //public int finalScore;
    // Start is called before the first frame update
    void Start()
    {
       gameObject.SetActive(false);
    }

    //This displays the final score in big text 
    public void displayFinalScore(int finalScore)
    {
        gameObject.SetActive(true);
        this.GetComponent<Text>().text = "Score:" + finalScore;
    }
}
