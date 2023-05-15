using System.Collections;
using System.Collections.Generic;
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
    public float moveSpeed = 500f;
    public Vector2 input = Vector2.zero;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public bool isMoving = false;

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
    }
}
