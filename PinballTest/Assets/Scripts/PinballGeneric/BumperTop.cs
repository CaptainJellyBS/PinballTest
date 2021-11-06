using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperTop : MonoBehaviour
{
    public bool startLit = true;
    bool isLit;
    public bool IsLit
    {
        get { return isLit; }
        set
        {
            isLit = value;
            foreach (GameObject go in litLights)
            {
                go.SetActive(isLit);
            }
            bumper.enabled = value;
        }
    }
    public List<GameObject> litLights;
    public List<Flasher> hitLights;
    
    Bumper bumper;
    public float bumperForce;
    public Color hitColor;

    // Start is called before the first frame update
    void Start()
    {
        bumper = GetComponentInChildren<Bumper>();
        bumper.bumperForce = bumperForce;

        IsLit = startLit;
    }

    public void HitLights()
    {
        foreach (Flasher f in hitLights)
        {
            f.Flash(hitColor, 0.1f);
        }
    }
}
