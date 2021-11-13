using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagsMission : MonoBehaviour
{
    public GameObject redFlags, blueFlags, greenFlags;
    StormTheCastleMission mainMis;
    GameObject currentFlag;

    private void Start()
    {
        mainMis = GetComponent<StormTheCastleMission>();
        currentFlag = null;
    }

    public void SetFlag(int flag)
    {
        switch(flag)
        {
            case 0:
                mainMis.AddSpinnerMultiplier(1);
                mainMis.AddSlingshotMultiplier(-1);
                mainMis.AddBumperMultiplier(-1);
                StartCoroutine(SwitchFlags(redFlags));
                break;
            case 1:
                mainMis.AddSpinnerMultiplier(-1);
                mainMis.AddSlingshotMultiplier(1);
                mainMis.AddBumperMultiplier(-1);
                StartCoroutine(SwitchFlags(greenFlags));

                break;
            case 2:
                mainMis.AddSpinnerMultiplier(-1);
                mainMis.AddSlingshotMultiplier(-1);
                mainMis.AddBumperMultiplier(1);
                StartCoroutine(SwitchFlags(blueFlags));

                break; 
            default: throw new System.ArgumentException("There. Are. Three. Flags.");
        }
    }

    IEnumerator MoveFlags(GameObject flags, int dir)
    {
        if(flags == null) { yield break; }
        Vector3 startPos = flags.transform.localPosition;
        Vector3 endPos = flags.transform.localPosition + Vector3.up * 2.0f * dir;

        float t = 0;
        while(t<=1.0f)
        {
            t += Time.deltaTime;
            flags.transform.localPosition = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }
    }

    IEnumerator SwitchFlags(GameObject up)
    {
        yield return StartCoroutine(MoveFlags(currentFlag, -1));
        currentFlag = up;
        yield return StartCoroutine(MoveFlags(up, 1));
    }
}
