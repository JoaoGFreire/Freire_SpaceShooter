using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    public float sightDistance;
    public float visionAngle;
    public Transform targetTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookingDirection = transform.up;
        float lookingAngle = Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg;


        float leftAngle = lookingAngle + visionAngle / 2;
        float rightAngle =lookingAngle - visionAngle / 2;

        Vector3 leftVector = new Vector3(Mathf.Cos(leftAngle * Mathf.Deg2Rad), Mathf.Sin(leftAngle * Mathf.Deg2Rad));
        Vector3 rightVector = new Vector3(Mathf.Cos(rightAngle * Mathf.Deg2Rad), Mathf.Sin(rightAngle * Mathf.Deg2Rad));

        


        bool targetIsCloseEnough = Vector3.Distance(transform.position, targetTransform.position) < sightDistance;

        bool targetIsInFOV = lookingAngle < leftAngle && lookingAngle > rightAngle;

        Color linecolor;
        
        if(targetIsCloseEnough && targetIsInFOV)
        {
            linecolor = Color.green;
        }
        else
        {
            linecolor = Color.red;
        }

        Debug.DrawLine(transform.position, leftVector * sightDistance + transform.position, linecolor);
        Debug.DrawLine(transform.position, rightVector * sightDistance + transform.position, linecolor);
    }
}
