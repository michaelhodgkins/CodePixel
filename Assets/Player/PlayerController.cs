using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    bool IsMoving { 
        set
        {
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }

    bool IsGrounded
    {
        set
        {
            isGrounded = value;
            animator.SetBool("isGrounded", isGrounded);

        }
    }

    //need to implement falling
    bool IsFalling
    {
        set
        {
            isFalling = value;
            animator.SetBool("isFalling", isFalling);
        }
    }

    bool HasJumped
    {
        set
        {
            hasJumped = value;
            animator.SetBool("hasJumped", hasJumped);
        }
    }
    public float moveSpeed = 500f;
    public Vector2 input = Vector2.zero;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public bool isMoving = false;
    public bool isFalling = false;
    public bool isGrounded;
    public bool hasJumped = false;
    public bool canJump = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


     void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    void OnJump()
    {
        Debug.LogWarning("Button works");
        if(rb.velocity.y == 0)
        {
            canJump = true;
        } else
        {
            canJump = false;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (input != Vector2.zero)
        {
            rb.AddForce(input * moveSpeed * Time.fixedDeltaTime);
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }

        if (input.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (input.x < 0)
        {
            spriteRenderer.flipX = true;
        }

       if(isGrounded && canJump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            HasJumped = true;
            canJump = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGrounded = true;
        HasJumped = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGrounded = false;
    }
}
