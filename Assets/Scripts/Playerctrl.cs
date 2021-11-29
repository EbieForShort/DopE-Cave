using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerctrl : MonoBehaviour
{
    public float playerSpeed;
    public float jumpSpeed;

    private bool isJumping;
    private float move;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//Gets the Rigidbody component from the player.
        anim = GetComponent<Animator>();//Gets the Animator component from the player.
    }

    // Update is called once per frame
    void Update()
    {
        RunAnimations();

        //Lines of code for player movement
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * playerSpeed, rb.velocity.y);// allows player to move left and right.

        if (move < 0)// lines of code that allows the player to face the direction his or she is facing.
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }else if (move > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetButtonDown("Jump") && !isJumping)// Lines of code that allows player to jump.
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
            isJumping = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)// Denies the player to jump multiple times off the ground.
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

    }

    void RunAnimations()// Lines of code for walking animation of player.
    {
        anim.SetFloat("Movement", Mathf.Abs(move));
    }
}
