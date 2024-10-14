using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle1 : MonoBehaviour
{
    float speed = 20f;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity = transform.up * speed;
        transform.position += transform.up * Time.deltaTime;
    }
}
