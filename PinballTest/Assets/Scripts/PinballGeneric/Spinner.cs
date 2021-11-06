using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spinner : MonoBehaviour
{
    public UnityEvent onHit;
    public bool scorable;

    // Update is called once per frame
    void Update()
    {
        if (scorable)
        {
            if (transform.rotation.eulerAngles.y > 170 || transform.rotation.eulerAngles.y < -170)
            {
                scorable = false;
                onHit.Invoke();
            }
        }
        else
        {
            if (transform.rotation.eulerAngles.y < 10 && transform.rotation.eulerAngles.y > -10)
            {
                scorable = true;                
            }
        }
    }
}
