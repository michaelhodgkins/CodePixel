using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 500f;
    public Vector2 input = Vector2.zero;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


     void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(input * moveSpeed * Time.fixedDeltaTime);
    }
}
