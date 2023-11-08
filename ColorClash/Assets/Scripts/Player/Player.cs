using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D body;
    public SpriteRenderer spriteRenderer;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    [SerializeField]
    private float runSpeed = 20.0f;

    [SerializeField]
    private int health;

    public bool isMoving;


    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        if (horizontal != 0 || vertical != 0) isMoving = true; else isMoving =false;

        //temporary disgusting hardcode solution oops
        if(horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }

    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {          
            Damage();
        }
    }

    void Damage()
    {
        health--;
        if(health <= 0)
        {
            //Write Death Logic here
        }
    }

}
