using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Control : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public float forwardSpeed = 30f;
    public GameObject[] bullets;
    public Transform bullet;
    public bool reload;
    public List<float> reloadTime;
    public GameObject ExplosionBP;
    public Transform here;
    public float life = 1.0f;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
      // reload = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (life < 1 && isDead == false){
            isDead = true;
            lifeCheck();
        }
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
            Debug.Log(rb.velocity);
        }
        //Moves the player back
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.up * -2);
        }

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Enemy")||hitInfo.CompareTag("Enemy Bullets"))
        {
            //Destroys the ship and explodes
            life--;

        }
    }
    void Loadd()
    {
        SceneManager.LoadScene(0);
        SceneManager.UnloadSceneAsync(1);
    }
    
    void lifeCheck()
    {
        GameObject clone = (GameObject)Instantiate(ExplosionBP, here.position, here.rotation);
        gameObject.SetActive(false);
        Invoke ("Loadd", 3);
    }
}

