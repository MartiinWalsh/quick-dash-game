using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{


    public GameObject loseScreen;
    public Text healthDisplay;
    
    public float speed;
    private float input;

    
    Rigidbody2D rb;
    Animator anim;
    AudioSource source;

    public int health;

    public float startDashTime;
    private float dashTime;
    public float extraSpeed;
    private bool isDashing;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthDisplay.text = health.ToString();
    }

    private void Update()
    {
        
        if (input != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        Vector3 localScale = transform.localScale;
        // Moving right
        if (input > 0)
        {
            localScale.x = 1;
        }
        else if (input < 0)
        {
            localScale.x = -1;
        }
        transform.localScale = localScale;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed += extraSpeed;
            isDashing = true;
            dashTime = startDashTime;
        }

        if(dashTime <= 0 && isDashing == true)
        {
            isDashing = false;
            speed -= extraSpeed;
        }

        else
        {
            dashTime -= Time.deltaTime;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        input = Input.GetAxisRaw("Horizontal");


        // Moving the player
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    public void Takedamage(int damageAmount)
    {
        source.Play();
        health -= damageAmount;
        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            loseScreen.SetActive(true);
            Destroy(gameObject);
        }

    }
}
