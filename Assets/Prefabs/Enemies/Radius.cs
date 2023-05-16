using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Radius : MonoBehaviour
{
    public GameObject player;
    public GameObject spider;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            transform.position = Vector2.MoveTowards(spider.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
