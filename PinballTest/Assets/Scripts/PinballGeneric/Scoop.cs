using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scoop : MonoBehaviour
{
    public Transform ballSpawn;
    public float delay;
    public UnityEvent onEnter, onExit;
    public GameObject ballPrefab;
    public float exitForce;
    bool ballIsIn = false;

    public void BallEnter()
    {
        StartCoroutine(ScoopC());
    }

    IEnumerator ScoopC()
    {
        if (ballIsIn) { yield break; }
        ballIsIn = true;

        onEnter.Invoke();
        yield return new WaitForSeconds(delay);

        Ball b = Instantiate(ballPrefab, ballSpawn.position, ballSpawn.rotation).GetComponent<Ball>();
        b.GetComponent<Rigidbody>().AddForce(b.transform.forward * exitForce, ForceMode.Impulse);

        onExit.Invoke();

        yield return new WaitForSeconds(0.2f);
        ballIsIn = false;
    }
}
