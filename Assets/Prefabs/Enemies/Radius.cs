using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Radius : MonoBehaviour
{
    public List<Collider2D> detectedObjs;
    public Collider2D col;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            detectedObjs.Add(collider);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        detectedObjs.Remove(collider);
    }
}
