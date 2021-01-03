using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private float input;

    
    Rigidbody2D rb;
    Animator anim;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
