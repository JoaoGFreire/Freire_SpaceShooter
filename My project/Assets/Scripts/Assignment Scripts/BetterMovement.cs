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

    public float ImprovedMaxSpeed;
    public float ImprovedAccelerationTime;

    private float ImprovedAcceleration;
    private float defaultAcceleration;


    // Start is called before the first frame update
    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
        ImprovedAcceleration = ImprovedMaxSpeed / ImprovedAccelerationTime;
        defaultAcceleration = acceleration;
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

    public void IncreaseSpeed()
    {
        acceleration = ImprovedAcceleration;
    }
    public void DecreaseSpeed()
    {
        Debug.Log("test");
        Debug.Log(acceleration.ToString());
        acceleration = defaultAcceleration;
    }
}
