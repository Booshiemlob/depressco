using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Player_Control pcon1;
    void Start()
    {

        gameObject.SetActive(false);
    }



    public void gameOver()
    {
        if (pcon1.isDead == true)
        { 
            gameObject.SetActive(true);
        }
    }


}
