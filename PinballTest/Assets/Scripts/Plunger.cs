using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : MonoBehaviour
{
    public KeyCode plungeButton = KeyCode.Space;
    public float pullSpeed;
    ConstantForce cf;
    Vector3 standardForce;
    public Vector3 forceAccel;

    private void Start()
    {
        cf = GetComponent<ConstantForce>();
        standardForce = cf.relativeForce;
    }

    private void Update()
    {
        if (Input.GetKeyDown(plungeButton)) { cf.enabled = false; cf.relativeForce = standardForce; }
        
        if (Input.GetKey(plungeButton) && transform.localPosition.z > -7.5f) 
        { 
            transform.Translate(-transform.forward * pullSpeed * Time.deltaTime);
            cf.relativeForce += forceAccel * Time.deltaTime;
        }
        
        if (Input.GetKeyUp(plungeButton)) { cf.enabled = true; }
    }
}
