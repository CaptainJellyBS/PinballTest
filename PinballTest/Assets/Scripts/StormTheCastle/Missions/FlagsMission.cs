using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlagsMission : MonoBehaviour
{
    public GameObject redFlags, blueFlags, greenFlags;
    StormTheCastleMission mainMis;
    GameObject currentFlag;
    bool nowSwitching = false;
    bool redFlagsUp = false, blueFlagsUp = false, greenFlagsUp = false;
    int currentFlagNumber;
    public UnityEvent allFlagsUp, flagReset;

    private void Start()
    {
        currentFlagNumber = -1;
        mainMis = GetComponent<StormTheCastleMission>();
        currentFlag = null;
    }

    public void SetFlag(int flag)
    {
        switch (flag)
        {
            case 0:
                mainMis.AddSpinnerMultiplier(1);
                if (currentFlagNumber == 1) { mainMis.AddSlingshotMultiplier(-1); }
                if (currentFlagNumber == 2) { mainMis.AddBumperMultiplier(-1); }
                redFlagsUp = true;

                StartCoroutine(SwitchFlags(redFlags));
                break;
            case 1:
                if (currentFlagNumber == 0) { mainMis.AddSpinnerMultiplier(-1); }
                mainMis.AddSlingshotMultiplier(1);
                if (currentFlagNumber == 2) { mainMis.AddBumperMultiplier(-1); }
                blueFlagsUp = true;
                StartCoroutine(SwitchFlags(greenFlags));

                break;
            case 2:
                if (currentFlagNumber == 0) { mainMis.AddSpinnerMultiplier(-1); }
                if (currentFlagNumber == 1) { mainMis.AddSlingshotMultiplier(-1); }
                mainMis.AddBumperMultiplier(1);
                greenFlagsUp = true;
                StartCoroutine(SwitchFlags(blueFlags));

                break; 
            default: throw new System.ArgumentException("There. Are. Three. Flags.");

        }

        currentFlagNumber = flag;

        if (redFlagsUp && blueFlagsUp && greenFlagsUp)
        {
            StartCoroutine(AllThreeUp());
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
        while (nowSwitching) { yield return null; }
        nowSwitching = true;
        yield return StartCoroutine(MoveFlags(currentFlag, -1));
        currentFlag = up;
        yield return StartCoroutine(MoveFlags(up, 1));
        nowSwitching = false;
    }

    IEnumerator AllThreeUp()
    {
        if (currentFlagNumber == 0) { mainMis.AddSpinnerMultiplier(-1); }
        if (currentFlagNumber == 1) { mainMis.AddSlingshotMultiplier(-1); }
        if (currentFlagNumber == 2) { mainMis.AddBumperMultiplier(-1); }
        redFlagsUp = false; blueFlagsUp = false; greenFlagsUp = false;
        currentFlagNumber = -1;

        yield return StartCoroutine(SwitchFlags(null));
        allFlagsUp.Invoke();
    }

    public void ResetFlags()
    {
        StartCoroutine(SwitchFlags(null));
        
        if (currentFlagNumber == 0) { mainMis.AddSpinnerMultiplier(-1); }
        if (currentFlagNumber == 1) { mainMis.AddSlingshotMultiplier(-1); }
        if (currentFlagNumber == 2) { mainMis.AddBumperMultiplier(-1); }
        currentFlagNumber = -1;

        flagReset.Invoke();
        redFlagsUp = false; blueFlagsUp = false; greenFlagsUp = false;
    }
}
