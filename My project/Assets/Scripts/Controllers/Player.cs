using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PLayer : MonoBehaviour

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
    private void Update()
    {

        //velocity += acceleration * transform.up * Time.deltaTime;
        //transform.position += velocity * Time.deltaTime;
        //transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y);
        //transform.position += velocity;
        //PlayerMovement();
        //EnemyMovement();
        EnemyRadar(radius, circlePoints);
        SpawnPowerups(radius2, numberOfPowerups);
        
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
    float EnemyAcceleration = 50f;
    float EnemyMaxSpeed = 200f;
    float EnemeyAccelerationTime = 2f;
    public void EnemyMovement()
    {
        velocity += EnemyAcceleration * transform.right * Time.deltaTime;
        transform.position += velocity.normalized * Time.deltaTime;
        Vector3 currenPos = Camera.main.ScreenToWorldPoint(transform.position);
        Camera cam = Camera.main;
        float cameraHeight = cam.orthographicSize;
        float cameraWidth = cam.aspect * cameraHeight;
        if(currenPos.x < cameraWidth)
        {
            Debug.Log("test");
        }
        if(currenPos.x > cameraWidth)
        {
            Debug.Log("test2");
        }

    }

    public int circlePoints;
    public float radius;
    public float radius2;
    public int numberOfPowerups;
    public GameObject powerupPrefab;


    public void EnemyRadar(float radius,int circlePoints)
    {
        Color circleColor = Color.green; //sets the defaut colour to green
        float dist = Vector3.Distance(transform.position,enemyTransform.position); //sets the float dist to the distance between the player and the enemy
        if(dist > radius) //if enemy is outside of radius, color will remain green
        {
            circleColor = Color.green; 
        }
        else //if enemy is inside of radius color will be red
        {
            circleColor = Color.red;
        }
        float numberOfAngles = 360/circlePoints; //number of angles based on number of points
        Vector3 offset = new Vector3(radius, 0, 0); //offset to determine where the circle will begin
        Vector3 Point = transform.position + offset; //sets the first point to be the current position + offset.

        for(int i = 1;i <= circlePoints;i++) //for each point in circlePoints
        {
            float angle = (numberOfAngles * i) * Mathf.Deg2Rad; //set the value for the current angle in radians

            Vector3 nextPoint = transform.position + new Vector3(Mathf.Cos(angle)*radius, Mathf.Sin(angle) * radius,0f); // set the next point to be the current
                                                                                                                         // position plus a new position where x is
            //the cosine of the current angle times radius and y is the sine of the current angle times radius
            Debug.DrawLine(Point, nextPoint,circleColor); //draw the line connecting the current and next points with the color specified earilier

            Point = nextPoint; // makes the current point the next point.
        }
    }

    public void SpawnPowerups(float radius,int numberOfPowerups)
    {
        float numberOfAngles = 360 / numberOfPowerups; //divides 360 by the number of powerups to make sure they are all equally spaced
        for(int i = 0; i < numberOfPowerups;i++) //or each powerup in number of powerups...
        {
            float angle = (numberOfAngles*i) * Mathf.Deg2Rad; //sets the value of the current angle in radians
            Vector3 PowerupPosition = transform.position + new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0f);
            //powerup position will be the player position offsetted by a new vector with an x value of the cosine of the currnent angle times radius and
            //a y avlue of the sine of the current angle times the radius.

            Instantiate(powerupPrefab, PowerupPosition, Quaternion.identity); //instantiates the prefab at Powerup position and at a rotation of 0.
        }
    }

}
