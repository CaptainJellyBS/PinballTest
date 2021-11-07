using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nudging : MonoBehaviour
{
    public KeyCode LeftButton = KeyCode.Period;
    public KeyCode RightButton = KeyCode.X;
    public KeyCode UpButton = KeyCode.UpArrow;

    public float nudgeDis = 0.1f;
    bool beingNudged = false;

    private void Update()
    {
        if(Input.GetKeyDown(LeftButton))
        {
            StartCoroutine(Nudge(Vector3.left));
        }
        
        if(Input.GetKeyDown(RightButton))
        {
            StartCoroutine(Nudge(Vector3.right));
        }
        
        if(Input.GetKeyDown(UpButton))
        {
            StartCoroutine(Nudge(Vector3.forward));
        }
    }

    IEnumerator Nudge(Vector3 nudge)
    {
        if (beingNudged) { yield break; }
        beingNudged = true;

        Vector3 origPos = transform.localPosition;
        transform.localPosition += (nudge * nudgeDis);
        yield return new WaitForSeconds(0.1f);

        transform.localPosition = origPos;

        beingNudged = false;
    }

}
