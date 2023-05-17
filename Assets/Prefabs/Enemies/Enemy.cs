using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float damage = 1f;

    public float movementSpeed = 300f;
    public Radius radius;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(radius.detectedObjs.Count > 0)
        {
            Vector2 direction = (radius.detectedObjs[0].transform.position - transform.position).normalized;
            rb.AddForce(direction * movementSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        IDamageable damageable = collider.GetComponent<IDamageable>();

        if(damageable != null)
        {
            damageable.OnHit(damage);
        }
    }
}
