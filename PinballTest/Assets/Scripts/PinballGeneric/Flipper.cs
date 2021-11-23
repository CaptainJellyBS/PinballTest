using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    Rigidbody rb;
    HingeJoint hj;
    public Transform forcePos;
    public float rotation;
    public KeyCode button;
    public AudioSource flipperUp, flipperDown;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        hj = GetComponent<HingeJoint>();

        

        JointLimits whyDoINeedToDoThis = hj.limits;
        whyDoINeedToDoThis.max = rotation;
        hj.limits = whyDoINeedToDoThis;
    }

    private void Update()
    {
        if(Input.GetKeyDown(button))
        {
            JointSpring fuckThis = hj.spring;
            fuckThis.targetPosition = rotation;
            hj.spring = fuckThis;
            flipperUp.Play();
        }

        if(Input.GetKeyUp(button))
        {
            JointSpring fuckThis = hj.spring;
            fuckThis.targetPosition = 0;
            hj.spring = fuckThis;
            flipperDown.Play();
        }

    }
}
