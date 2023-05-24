using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{

    public float swordDamage = 1f;
    public Collider2D swordCollider;
    // Start is called before the first frame update
    void Start()
    {
        if(swordCollider == null)
        {
            Debug.LogWarning("Sword collider not set");
        }
    }

     void OnTriggerEnter2D(Collider2D coll)
    {
        IDamageable damageable = coll.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.OnHit(swordDamage);
        }
    }
}
