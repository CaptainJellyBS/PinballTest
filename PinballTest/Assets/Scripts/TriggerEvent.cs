using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public bool destroyColliderOnEnter = false;

    public UnityEvent onTriggerEnter, onTriggerExit;

    private void Start()
    {
        //Make triggers invisible
        foreach(Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke();
        if (destroyColliderOnEnter) { Destroy(other.gameObject); }
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke();
    }
}
