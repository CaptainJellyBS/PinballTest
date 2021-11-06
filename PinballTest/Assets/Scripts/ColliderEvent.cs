using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEvent : MonoBehaviour
{
    public bool destroyColliderOnEnter = false;

    public UnityEvent onColliderEnter, onColliderExit;

    private void OnCollisionEnter(Collision collision)
    {
        onColliderEnter.Invoke();
        if (destroyColliderOnEnter) { Destroy(collision.gameObject); }
    }

    private void OnCollisionExit(Collision collision)
    {
        onColliderExit.Invoke();
    }
}
