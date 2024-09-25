using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseTrig : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Cos(45): " + Mathf.Cos(45 * Mathf.Deg2Rad));
        Debug.Log("Cos(-45): " + Mathf.Cos(-45 * Mathf.Deg2Rad));

        Debug.Log("ACos(Cos(45)) " + Mathf.Acos(Mathf.Cos(45 * Mathf.Deg2Rad)) * Mathf.Rad2Deg);
        Debug.Log("ACos(Cos(-45)) " + Mathf.Acos(Mathf.Cos(-45 * Mathf.Deg2Rad)) * Mathf.Rad2Deg);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
