using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    PlayerInput input;
    public float maxSpeed = 50f;
    public float jumpPower = 250f;
    public bool isJump = false;
    bool facingRight = true;
    public bool grounded = true;
    private Rigidbody2D rigi;

    public Animator anim;

    public float moveForce = 365f;

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody2D>();
        input = gameObject.GetComponent<PlayerInput>();
    }

    void Update()
    {
        anim.SetBool("grounded", grounded);



        if (input.inputJumpCheck == true && grounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        anim.SetBool("grounded", false);
        rigi.velocity = new Vector2(rigi.velocity.x, jumpPower);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        if (input.attack == true)
        {
            Attack();
        }

        if (move > 0 || move < 0)
        {
            Move(move);
        }

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    void Attack()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
        anim.SetBool("Attack", true);
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }

    void Move(float move)
    {
        anim.SetFloat("Speed", Mathf.Abs(move));

        rigi.velocity = new Vector2(move * maxSpeed, rigi.velocity.y);
    }
}