using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnterExitMission : MonoBehaviour
{
    public Transform leftBottomSpawn, rightBottomSpawn, leftTopSpawn, rightTopSpawn;
    public float topForce, bottomForce;
    public GameObject ball;
    bool topExited = false;

    public void ExitLeftBottom()
    {
        StartCoroutine(LeftToRight());
    }

    public void ExitRightBottom()
    {
        StartCoroutine(RightToLeft());
    }

    public void ExitTop()
    {
        topExited = true;
    }

    IEnumerator LeftToRight()
    {
        topExited = false;
        yield return new WaitForSeconds(1.0f);
        SpawnBall(leftTopSpawn, topForce);

        while (!topExited) { yield return null; }

        SpawnBall(rightBottomSpawn, bottomForce);
    }

    IEnumerator RightToLeft()
    {
        topExited = false;
        yield return new WaitForSeconds(1.0f);
        SpawnBall(rightTopSpawn, topForce);

        while (!topExited) { yield return null; }

        SpawnBall(leftBottomSpawn, bottomForce);
    }

    void SpawnBall(Transform spawnPoint, float forceStrength)
    {
        GameObject b = Instantiate(ball, spawnPoint.position, spawnPoint.rotation);
        b.GetComponent<Rigidbody>().AddForce(b.transform.forward * forceStrength, ForceMode.Impulse);
    }
}
