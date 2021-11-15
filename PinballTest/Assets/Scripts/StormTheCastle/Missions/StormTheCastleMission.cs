using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Handles scoring and game state of the entire Storm The Castle mission. Mission specific sequences are in their respective scripts.
public class StormTheCastleMission : MonoBehaviour
{
    public float spinnerMultiplier = 1, bumperMultiplier = 1, slingshotMultiplier = 1, dropTargetMultiplier = 1, staticTargetMultiplier = 1, scoreMultiplier = 1;

    #region scoring

    #region scoring
    public void ScoreSlingshot(int _score)
    {
        Score((int)(_score * slingshotMultiplier));
    } 
    
    public void ScoreBumper(int _score)
    {
        Score((int)(_score * bumperMultiplier));
    }

    public void ScoreSpinner(int _score)
    {
        Score((int)(_score * spinnerMultiplier));
    }

    public void ScoreDropTarget(int _score)
    {
        Score((int)(_score * dropTargetMultiplier));
    }
        public void ScoreStaticTarget(int _score)
    {
        Score((int)(_score * staticTargetMultiplier));
    }

    void Score(int _score)
    {
        GameManager.Instance.AddScore((int)(_score * scoreMultiplier));
    }
    #endregion

    #region multipliers
    public void AddSpinnerMultiplier(float _add)
    {
        spinnerMultiplier += _add;
    }

    public void AddBumperMultiplier(float _add)
    {
        bumperMultiplier += _add;
    }

    public void AddSlingshotMultiplier(float _add)
    {
        slingshotMultiplier += _add;
    }

    public void AddDropTargetMultiplier(float _add)
    {
        dropTargetMultiplier += _add;
    }  
    
    public void AddStaticTargetMultiplier(float _add)
    {
        staticTargetMultiplier += _add;
    }
    #endregion
    #endregion
}
