using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Vector3 ballSpawnPos;
    public GameObject ball;
    public int amountOfBallsLeft = 3;
    public int activeBalls = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnBall();
    }

    private void Update()
    {
        //debug
        if (Input.GetKeyDown(KeyCode.R)) { SpawnBall(); }
    }

    public void Die()
    {
        DieRoutine();
    }

    public Coroutine DieRoutine()
    {
        activeBalls--;
        if (activeBalls <= 0)
        {
            return StartCoroutine(DieC());
        }
        
        return null;
    }

    IEnumerator DieC()
    {

        yield return null;
        //Death events and the such
        SpawnBall();
    }

    public void SpawnBall()
    {
        if(amountOfBallsLeft <= 0) { GameOver(); return; }
        amountOfBallsLeft--;
        activeBalls++;
        Instantiate(ball, ballSpawnPos, Quaternion.identity);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
    #region debug

    #endregion
}
