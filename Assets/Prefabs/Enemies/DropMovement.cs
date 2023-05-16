using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMovement : MonoBehaviour

{
    Vector3 startingPos;
    Transform transformPos;
    public float pingPongL = 4;

    // Start is called before the first frame update
    void Start()
    {
        transformPos = GetComponent<Transform>();
        startingPos = transformPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(startingPos.x, startingPos.y + Mathf.PingPong(Time.time, pingPongL), startingPos.z);
    }
}
