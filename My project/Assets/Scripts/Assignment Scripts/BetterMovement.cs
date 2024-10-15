using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterMovement : MonoBehaviour
{
    public float maxSpeed;
    public Transform BoostPad;
    private Vector3 currentVelocity;

    public float accelerationTime;
    private float acceleration;

    public float decelerationTime;
    private float deceleration;

    public float ImprovedMaxSpeed; //improved max speed value (set in unity)
    public float ImprovedAccelerationTime; //improved acceleration time (set in unity)

    private float ImprovedAcceleration;//improved acceleration value
    private float defaultAcceleration; //default acceleration value of the player


    // Start is called before the first frame update
    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
        ImprovedAcceleration = ImprovedMaxSpeed / ImprovedAccelerationTime; //calculates improved acceleration
        defaultAcceleration = acceleration; // makes the default acceleration the original acceleration value of max speed
                                            // divided by acceleration time

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Debug.Log(acceleration.ToString());
    }
    public void Movement()
    {
        Vector2 currentInput = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentInput += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentInput += Vector2.right;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentInput += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentInput += Vector2.down;
        }

        if (currentInput.magnitude > 0)
        {
            //accelerating
            currentVelocity += acceleration * Time.deltaTime * (Vector3)currentInput.normalized;

            if (currentVelocity.magnitude > maxSpeed)
            {
                currentVelocity = currentVelocity.normalized * maxSpeed;
            }
        }
        else
        {
            //decelerating
            Vector3 velocityDelta = (Vector3)currentVelocity.normalized * deceleration * Time.deltaTime;
            if (velocityDelta.magnitude > currentVelocity.magnitude)
            {
                currentVelocity = Vector3.zero;
            }
            else
            {
                currentVelocity -= velocityDelta;
            }
        }
        transform.position += currentVelocity * Time.deltaTime;
    }

    //changes acceleration to improved acceleration
    //which is equal to the improved max speed divided improved acceleration time
    //both values are determined in engine

    public void IncreaseSpeed()
    {
        acceleration = ImprovedAcceleration;
    }
    public void DecreaseSpeed() // changes acceleration back to its original value.
    {
        //Debug.Log("test");
        //Debug.Log(acceleration.ToString());
        acceleration = defaultAcceleration;
    }
}
