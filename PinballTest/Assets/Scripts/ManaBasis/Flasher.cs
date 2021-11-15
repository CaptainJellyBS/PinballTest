using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flasher : MonoBehaviour
{
    Renderer[] renderers;
    bool canFlash = true;
    bool active = true;

    private void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    public void Flash(Color color, float FlashTime)
    {
        StartCoroutine(FlashC(color, FlashTime, FlashTime, FlashTime * 2));
    }

    public void Flash(Color color, float FlashTime, int amount)
    {
        StartCoroutine(FlashC(color, FlashTime, FlashTime, amount * (FlashTime * 2)));
    }

    public void Flash(Color color, float offTime, float onTime, int amount)
    {
        StartCoroutine(FlashC(color, offTime, onTime, amount * (offTime + onTime)));
    }

    public void Flash(Color color, float FlashTime, float totalDuration)
    {
        StartCoroutine(FlashC(color, FlashTime, FlashTime, totalDuration));
    }

    public void Flash(Color color, float offTime, float onTime, float totalDuration)
    {
        StartCoroutine(FlashC(color, offTime, onTime, totalDuration));
    }

    IEnumerator FlashC(Color color, float offTime, float onTime, float totalDuration)
    {
        if (!canFlash || !active) { yield break; }
        canFlash = false;
        Dictionary<Renderer, Color> origColors = new Dictionary<Renderer, Color>();

        foreach (Renderer r in renderers)
        {
            r.material.EnableKeyword("_EMISSION");
            origColors.Add(r, r.material.color);
        }

        float t = 0;
        while (t < totalDuration)
        {
            t += Time.deltaTime;



            foreach (Renderer r in renderers)
            {
                r.material.SetColor("_EmissionColor", color);
                r.material.color = color;
            }

            yield return new WaitForSeconds(onTime);
            t += onTime;

            foreach (Renderer r in renderers)
            {
                r.material.SetColor("_EmissionColor", Color.black);
                r.material.color = origColors[r];
            }
            yield return new WaitForSeconds(offTime);
            t += offTime;
        }

        foreach (Renderer r in renderers)
        {
            r.material.SetColor("_EmissionColor", Color.black);
            r.material.color = origColors[r];

            r.material.DisableKeyword("_EMISSION");

        }
        canFlash = true;
    }

    public void EnableFlasher(bool on)
    {
        active = on;
    }
}
