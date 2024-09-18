using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //private Vector3 velocity = Vector3.right * 0.001f;
    private Vector3 velocityVert = Vector3.up * 0.001f;
    private Vector3 velocity = Vector3.zero;


    //The amount of time it will take to reach the target speed
    private float timeToReachSpeed = 3f;
    //The speed that we want the character to reach after a certain amount of time
    private float targetSpeed = 2f;



    private float acceleration = 1f;
    private Vector3 maxSpeed = new Vector3(5,5,0);
    private void Start()
    {
        acceleration = targetSpeed / timeToReachSpeed;
    }
    void Update()
    {

        //velocity += acceleration * transform.up * Time.deltaTime;
        //transform.position += velocity * Time.deltaTime;
        //transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y);
        //transform.position += velocity;
        PlayerMovement();
        
    }
    
    public void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            velocity += acceleration * transform.up * Time.deltaTime;
            Debug.Log(velocity);
            if ( velocity.magnitude > maxSpeed.y)
            {
                velocity.y = maxSpeed.y;
            }
            transform.position += velocity.normalized * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.DownArrow)) 
        {
            velocity += acceleration * -transform.up * Time.deltaTime;
            Debug.Log(velocity);
            if ( velocity.magnitude > maxSpeed.y)
            {
                velocity.y = -maxSpeed.y;
            }
            transform.position += velocity.normalized * Time.deltaTime; 
        }

        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            velocity += acceleration * transform.right * Time.deltaTime;
            Debug.Log(velocity);
            if (velocity.magnitude > maxSpeed.x)
            {
                velocity.x = maxSpeed.x;
            }
            transform.position += velocity.normalized * Time.deltaTime; 
        }
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            velocity += acceleration * -transform.right * Time.deltaTime;
            Debug.Log(velocity);
            if (velocity.magnitude > maxSpeed.x)
            {
                velocity.x = -maxSpeed.x;
            }
            transform.position += velocity.normalized * Time.deltaTime; 

        }

    }

}
