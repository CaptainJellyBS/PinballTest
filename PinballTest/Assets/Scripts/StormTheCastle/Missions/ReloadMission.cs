using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReloadMission : MonoBehaviour
{
    bool cannonNeedsReloading;
    public bool[] reloadLit;
    public GameObject[] litTargets, unlitTargets;
    public UnityEvent onReload, onExtra;

    // Start is called before the first frame update
    void Start()
    {
        reloadLit = new bool[litTargets.Length]; ;
        for (int i = 0; i < reloadLit.Length; i++)
        {
            reloadLit[i] = false;
        }
        cannonNeedsReloading = false;    
    }

    public void LetterShot(int i)
    {
        reloadLit[i] = true;

        foreach(bool lit in reloadLit)
        {
            if (!lit) { return; }
        }

        ResetLetters();
        if (cannonNeedsReloading) { onReload.Invoke(); cannonNeedsReloading = false; return; }
        onExtra.Invoke(); 
    }

    public void CannonShot()
    {
        cannonNeedsReloading = true;
    }

    public void ResetCannonShot()
    {
        cannonNeedsReloading = false;
    }

    public void ResetLetters()
    {
        for (int i = 0; i < reloadLit.Length; i++)
        {
            reloadLit[i] = false;
        }

        foreach(GameObject g in litTargets)
        {
            g.SetActive(false);
        }
        
        foreach (GameObject g in unlitTargets)
        {
            g.SetActive(true);
        }
    }
}
