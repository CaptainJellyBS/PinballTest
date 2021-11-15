using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCycler : MonoBehaviour
{
    public Flasher[] lights;
    public enum FlashPattern { AllTogether, Sequential, Random, RandomSequence, RandomMultiple, Alternating }
    Coroutine flashRoutine;
    public float flashTime = 0.1f;
    public Color color;
    public Color[] multiColor;

    public bool isFlashing;
    public bool multipleColors = false;
    public FlashPattern pattern;

    private void Start()
    {
        if(isFlashing)
        {
            StartFlashing();
        }
    }

    public void StartFlashing()
    {
        if(flashRoutine != null) { StopCoroutine(flashRoutine); }
        flashRoutine = StartFlashingC();
    }

    Coroutine StartFlashingC()
    {
        switch (pattern)
        {
            case FlashPattern.AllTogether: return StartCoroutine(FlashAllTogether()) ;
            case FlashPattern.Sequential: return StartCoroutine(FlashSequential());
            case FlashPattern.Random: return StartCoroutine(FlashRandom());
            case FlashPattern.RandomSequence: return StartCoroutine(FlashRandomSequence());
            case FlashPattern.RandomMultiple: return StartCoroutine(FlashRandomMultiple());
            case FlashPattern.Alternating: return StartCoroutine(FlashAlternating());
            default: return StartCoroutine(FlashAllTogether());
        }
    }

    public void StopFlashing()
    {
        if(flashRoutine == null) { return; }
        StopCoroutine(flashRoutine);
        flashRoutine = null;
    }

    IEnumerator FlashAllTogether()
    { 
        while(true)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                if (multipleColors) { lights[i].Flash(multiColor[i], flashTime); }
                else { lights[i].Flash(color, flashTime); }
            }
            yield return new WaitForSeconds(flashTime * 2);
        }
    }

    IEnumerator FlashSequential()
    {
        while (true)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                if (multipleColors) { lights[i].Flash(multiColor[i], flashTime); }
                else { lights[i].Flash(color, flashTime); }
                yield return new WaitForSeconds(flashTime);
            }
        }
    }

    IEnumerator FlashRandom()
    {
        while (true)
        {
            int i = Random.Range(0, lights.Length);
            if (multipleColors) { lights[i].Flash(multiColor[i], flashTime); }
            else { lights[i].Flash(color, flashTime); }
            yield return new WaitForSeconds(flashTime);
            
        }
    }

    IEnumerator FlashRandomSequence()
    {
        while (true)
        {
            Utility.FisherYates<Flasher>(ref lights);
            for (int i = 0; i < lights.Length; i++)
            {
                if (multipleColors) { lights[i].Flash(multiColor[i], flashTime); }
                else { lights[i].Flash(color, flashTime); }
                yield return new WaitForSeconds(flashTime);
            }
        }
    }

    IEnumerator FlashRandomMultiple()
    {
        while (true)
        {
            Utility.FisherYates<Flasher>(ref lights);
            for (int i = 0; i < Random.Range(0,lights.Length); i++)
            {
                if (multipleColors) { lights[i].Flash(multiColor[i], flashTime); }
                else { lights[i].Flash(color, flashTime); }
            }
            yield return new WaitForSeconds(flashTime);
        }
    }

    IEnumerator FlashAlternating()
    {
        while (true)
        {
            for (int i = 0; i < lights.Length; i += 2)
            {
                if (multipleColors) { lights[i].Flash(multiColor[i], flashTime); }
                else { lights[i].Flash(color, flashTime); }
            }
            yield return new WaitForSeconds(flashTime);

            for (int i = 1; i < lights.Length; i += 2)
            {
                if (multipleColors) { lights[i].Flash(multiColor[i], flashTime); }
                else { lights[i].Flash(color, flashTime); }
            }
            yield return new WaitForSeconds(flashTime);
        }
    }
}
