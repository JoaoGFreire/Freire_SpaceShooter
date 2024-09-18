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
    //private Vector3 velocityVert = Vector3.up * 0.001f;
    private Vector3 velocity = Vector3.zero;
    private float speed = 5;

    //The amount of time it will take to reach the target speed
    private float AccelerationTime = 3f;
    //The speed that we want the character to reach after a certain amount of time
    private float MaxSpeed = 5f;
    //how much the player will accelerate by
    private float acceleration = 1f;


    private void Start()
    {
        acceleration = MaxSpeed / AccelerationTime;
        EnemyAcceleration = EnemyMaxSpeed / EnemeyAccelerationTime;
    }
    void Update()
    {

        //velocity += acceleration * transform.up * Time.deltaTime;
        //transform.position += velocity * Time.deltaTime;
        //transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y);
        //transform.position += velocity;
        //PlayerMovement();
        EnemyMovement();
        
    }
    

    //PlayerMovement uses the variables velocity which is equal to  Vector3.zero and speed which is a float with the value of 5
    //PlayerMovement takes the users input from the 4 arrow keys and moves the player object in the respective direction
    public void PlayerMovement2()
    {
        if(Input.GetKey(KeyCode.UpArrow)) // if statement checks if the up arrow key was pressed
        {
            velocity = speed * Vector3.up; //velocity ( which started as 0) is now set to be speed times Vector3.up
                                           //vector3.up in this case acts the same as vector 3 with the value of (0,1,0). Meaning that the velocity now is (0,5f,0)
            transform.position += velocity.normalized * Time.deltaTime;
            //the players position is then summed with the normalized value of velocity and Time.deltaTime so that the frame rate doesnt affect the player's speed.
        }
        if (Input.GetKey(KeyCode.DownArrow)) // if statement checks if the down arrow key was pressed
        {
            velocity = speed * Vector3.down;//velocity ( which started as 0) is now set to be speed times Vector3.down
                                            //vector3.down in this case acts the same as vector 3 with the value of (0,-1,0). Meaning that the velocity now is (0,-5f,0)
            transform.position += velocity.normalized * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.RightArrow)) // if statement checks if the right arrow key was pressed
        {
            velocity = speed * Vector3.right;//velocity ( which started as 0) is now set to be speed times Vector3.right
                                             //vector3.right in this case acts the same as vector 3 with the value of (1,0,0). Meaning that the velocity now is (5f,0,0)
            transform.position += velocity.normalized * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // if statement checks if the left arrow key was pressed
        {
            velocity = speed * Vector3.left;//velocity ( which started as 0) is now set to be speed times Vector3.left
                                            //vector3.left in this case acts the same as vector 3 with the value of (-1,0,0). Meaning that the velocity now is (-5f,0,0)
            transform.position += velocity.normalized * Time.deltaTime;
        }
    }

    public void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            velocity += acceleration * transform.up * Time.deltaTime; // velocity is now equal to it plus acceleration times the current vertical transform of the player and Time.deltaTime
                                                                      //the player's transform is being used this time because the speed will built up onto itself, constantly increasing until the max value
                                                                      //differently from velocity which is constant.
            Debug.Log(velocity);
            if (velocity.magnitude > MaxSpeed) //this if statement checks if the current velocity is greater than the determined MaxSpeed, and if so will set its value to 
            {                                  // the max speed so that it doesnt exceed it
                velocity.y = MaxSpeed;
            }
            transform.position += velocity.normalized * Time.deltaTime; // the transform position is added to itself plus the normalized velocity times delta time.
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            velocity -= acceleration * transform.up * Time.deltaTime;
            transform.position += velocity.normalized * Time.deltaTime;


            
        }
        if (Input.GetKey(KeyCode.DownArrow)) 
        {
            velocity += acceleration * -transform.up * Time.deltaTime; //transform.up is negative because it is a downwards movement
            Debug.Log(velocity);
            if (velocity.magnitude > MaxSpeed)
            {
                velocity.y = -MaxSpeed;
            }
            transform.position += velocity.normalized * Time.deltaTime; 
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if(velocity.magnitude > 0)
            {
                velocity -= acceleration * transform.up * Time.deltaTime;
                transform.position += velocity.normalized * Time.deltaTime;
            }
            velocity = Vector3.zero;
            //transform.position += velocity.normalized * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            velocity += acceleration * transform.right * Time.deltaTime; //transform.right because the player moves to the right
            Debug.Log(velocity);
            if (velocity.magnitude > MaxSpeed)
            {
                velocity.x = MaxSpeed;
            }
            transform.position += velocity.normalized * Time.deltaTime; 
        }
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            velocity += acceleration * -transform.right * Time.deltaTime;//transform.right is negative because it is moving to the left.
            Debug.Log(velocity);
            if (velocity.magnitude > MaxSpeed)
            {
                velocity.x = -MaxSpeed;
            }
            transform.position += velocity.normalized * Time.deltaTime; 

        }

    }
    float EnemyAcceleration = 2f;
    float EnemyMaxSpeed = 20f;
    float EnemeyAccelerationTime = 2f;
    public void EnemyMovement()
    {
        velocity += acceleration * transform.right * Time.deltaTime;
        transform.position += velocity.normalized * Time.deltaTime;
        Vector3 currenPos = Camera.main.WorldToViewportPoint(transform.position);
        if(currenPos.x > 0)
        {
            Debug.Log("test");
        }

    }

}
