using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropTarget : MonoBehaviour
{
    public GameObject up, down;
    public GameObject[] litLights;
    public UnityEvent onHit;
    public bool isRaised, isLit;

    private void Start()
    {
        up.SetActive(isRaised);
        down.SetActive(!isRaised);
    }

    public void Drop()
    {
        up.SetActive(false);
        down.SetActive(true);
        isRaised = false;
    }

    public void Raise()
    {
        up.SetActive(true);
        down.SetActive(false);
        isRaised = true;
    }

    public void Toggle()
    {
        if (isRaised) { Drop(); return; }
        Raise(); return;
    }

    public void Hit()
    {
        onHit.Invoke();
        Drop();
    }
}
