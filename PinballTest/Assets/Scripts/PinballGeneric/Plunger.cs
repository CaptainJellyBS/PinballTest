using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : MonoBehaviour
{
    public KeyCode plungeButton = KeyCode.Space;
    SpringJoint sj;
    Rigidbody rb;
    public float pullForce;
    
    float origSpring;

    // Start is called before the first frame update
    void Start()
    {
        sj = GetComponent<SpringJoint>();        
        rb = GetComponent<Rigidbody>();
        origSpring = sj.spring;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(plungeButton))
        {
            sj.spring = 0;
        }
        
        if(Input.GetKey(plungeButton))
        {
            //rb.AddForce(-transform.forward * pullForce);
            rb.MovePosition(transform.position - transform.forward * pullForce * Time.deltaTime);
        }
        
        if (Input.GetKeyUp(plungeButton))
        {
            sj.spring = origSpring;
        }
    }
}
