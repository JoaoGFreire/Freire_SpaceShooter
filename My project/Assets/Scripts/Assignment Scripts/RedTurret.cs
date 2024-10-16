using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTurret : MonoBehaviour
{
    public float angularSpeed; //rotate speede
    public float timer = 0; //timer
    public float interval; //interval for shooting missle
    public GameObject misslePrefab; //missle game object
    public GameObject Spawn; //game object to where spawn missle
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,angularSpeed * Time.deltaTime); //tells red turret, to rotate at angular speed
        timer += Time.deltaTime; //increases timer based on time.deltaTime
        if(timer >= interval) //if the timer is ever greater than the interval then
        {
            //Debug.Log("hello");
            Instantiate(misslePrefab,Spawn.transform.position,Spawn.transform.rotation); //instantiate the missle at the
                                                                                         //spawn position and at the spawn's rotation

            timer = 0; //resets the timer to zero
        }
    }
}
