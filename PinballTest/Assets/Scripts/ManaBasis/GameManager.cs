using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{    
    public static GameManager Instance { get; private set; }
    public UnityEvent OnDrain;
    public AudioSource ballSpawnSound, drainSound;
    long score;
    public long Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreText.text = score.ToString();
        }
    }
    [Header("UI elements")]
    public Text scoreText;
    public Text gameOverText;

    [Header("Other")]
    //public Vector3 ballSpawnPos;
    public Transform ballSpawnPos;
    public GameObject ball;
    public int amountOfBallsLeft = 3;
    public int activeBalls = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Score = 0;
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
        OnDrain.Invoke();

        yield return null;
        //Death events and the such
        if (amountOfBallsLeft >= 1) 
        { 
            SpawnBall();
            amountOfBallsLeft--;
        }
        else { GameOver(); }
    }

    public void SpawnBall()
    {
        ballSpawnSound.Play();
        activeBalls++;
        Instantiate(ball, ballSpawnPos.position, ballSpawnPos.rotation);
    }

    public void AddScore(int _score)
    {
        Score += _score;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        gameOverText.gameObject.SetActive(true);
    }

    public void DebugLog(string log)
    {
        Debug.Log(log);
    }
    #region debug

    #endregion
}
