using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        moveSpeed = 3f;
        jumpForce = 30f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Using 0.1 just as a margin of error.
        if(moveHorizontal > 0.1f || moveHorizontal < -.01f)
        {
            // If we want the player to move when jumping,
            // we would have to change the 0f to a vertical movement.
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }
        if (moveVertical > 0.1f || moveVertical < -.01f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * moveSpeed), ForceMode2D.Impulse);

        }
        /*if (moveVertical > 0.1f && !isJumping)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);

        }*/
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Plateform")
        {
            isJumping = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plateform")
        {
            isJumping = true;
        }
    }
}
