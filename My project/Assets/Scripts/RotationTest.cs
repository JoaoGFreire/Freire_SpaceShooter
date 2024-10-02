using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public float AngularSpeed;
    //float angle = 0;
    public float TargetAngle;
    public Transform TargetTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        //UnityEngine.Vector3 testVector = new UnityEngine.Vector3(0,0,TargetAngle);
    }

    // Update is called once per frame
    void Update()
    {

        //float distance = UnityEngine.Vector3.Distance(transform.position, TargetTransform.position);
        //float NewAngle = (Mathf.Asin(TargetTransform.position.y / distance)) * Mathf.Rad2Deg;

        //NewAngle = StandardizeAngle(NewAngle);
        //Debug.Log(NewAngle);

        UnityEngine.Vector3 newTarget = TargetTransform.position - transform.position;
        float newTargetAngle = (Mathf.Atan2(newTarget.y, newTarget.x)) * Mathf.Rad2Deg;

        if(transform.eulerAngles.z < newTargetAngle)
        {
            transform.Rotate(0, 0, AngularSpeed * Time.deltaTime);
        }
        if(transform.eulerAngles.z > newTargetAngle)
        {
            transform.eulerAngles = new UnityEngine.Vector3(transform.eulerAngles.x, transform.eulerAngles.y, newTargetAngle);
        }
        
        
        
        
        
        
        
        
        ////angle += AngularSpeed * Time.deltaTime;
        //UnityEngine.Vector3 testVector = new UnityEngine.Vector3(0, 0, TargetAngle);
        //Debug.DrawLine(transform.position, transform.up, Color.red);
        //Debug.DrawLine(transform.position, TargetTransform.position, Color.blue);
        //if (transform.eulerAngles.z >= testVector.z )
        //{
        //    TargetAngle = 0;
        //}
        //else
        //{
        //    transform.Rotate(0, 0, AngularSpeed * Time.deltaTime);
        //}
        
        //if(transform.eulerAngles.z <= TargetAngle)
        //{

        //}
        

    }
    //This method will convert any provided angle so that it is between 
    //-180 and 180
    public float StandardizeAngle(float inAngle)
    {
        inAngle = inAngle % 360;

        inAngle = (inAngle + 360) % 360;

        if (inAngle > 180)
        {
            inAngle -= 360;
        }
        return inAngle;
    }
}
