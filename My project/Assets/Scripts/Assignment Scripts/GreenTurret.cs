using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTurret : MonoBehaviour
{
    public float timer; 
    public float interval; //interval for timer
    public GameObject misslePrefab; //missile object
    public GameObject Spawn; //spawn object
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //timer increase by time.deltaTime
        if(timer >= interval) // if timer is greater then interval
        {
            Instantiate(misslePrefab, Spawn.transform.position, Spawn.transform.rotation); //spawn missle at spawn position and rotation
            timer = 0;
        }
    }
}

