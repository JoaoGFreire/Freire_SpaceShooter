using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle1 : MonoBehaviour
{
    float speed = 20f; //speed of missile
    Vector3 velocity; //velocity vector
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity = transform.up * speed; //uses transform up so that it goes straight relative to the missle
        transform.position += transform.up * Time.deltaTime; 
    }
}
