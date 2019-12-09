using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Control : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public float forwardSpeed = 30f;
    public GameObject ExplosionBP;
    public Transform here;
    public float life = 1f;
    public bool isDead = false;
    public BigText bigtext;
    public ScoreScript score;
    public ScoreScript score2;
    public bool immortal = false;
    public GameObject end_scorer;
    public WeaponEquip weapEq;
    public CoolDownUI coolDownUI;

    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.Find("player");
       end_scorer = GameObject.Find("scoretext 2");
       rb = GetComponent<Rigidbody2D>();
       score = GameObject.Find("scoretext").GetComponent<ScoreScript>();
       score2 = GameObject.Find("scoretext 2").GetComponent<ScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (life < 0 && isDead == false){
            isDead = true;
            lifeCheck();
        }
        Debug.Log("tree");
        coolDownUI.HealthBarSetSize(life);
        life += 0.01f * Time.deltaTime;
        if (life >= 1)
        {
            life = 1;
        }
        Debug.Log("Elon");
    }
    void Movement()
    {
        //Increases player speed if LeftShift if held down
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            forwardSpeed = 50f;
        }
        //Reverts the player speed to normal when LeftShift is let go
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            forwardSpeed = 30f;
        }
        //Turns the player left
            if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(0.5f);
        }
        //turns the player right
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-0.5f);
        }
        //Moves the player forward
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up * forwardSpeed);

        }
        //Moves the player back
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.up * -2);
        }

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (immortal == false)
        {

            if (hitInfo.CompareTag("Enemy") || hitInfo.CompareTag("Enemy Bullets"))
            {
                //Destroys the ship and explodes
                life -= .2f;
            }
        }
    }
    void Loadd()
    {
        SceneManager.LoadScene("Start Menu");
        SceneManager.UnloadSceneAsync("Game");
    }

    void lifeCheck()
    {
        GameObject clone = (GameObject)Instantiate(ExplosionBP, here.position, here.rotation);
        gameObject.SetActive(false);
        end_scorer.SetActive(true);
        Debug.Log("FinalScore!");
        Invoke("Loadd", 5);
    }



}

