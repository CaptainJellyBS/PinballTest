using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotTop : MonoBehaviour
{
    public bool startLit = true;
    bool isLit;
    public bool IsLit
    {
        get { return isLit; }
        set
        {
            isLit = value;
            foreach(GameObject go in litLights)
            {
                go.SetActive(isLit);
            }
            slingshot.enabled = value;
        }
    }
    public List<GameObject> litLights;
    public List<Flasher> hitLights;
    Slingshot slingshot;
    public float slingshotForce;
    public Color hitColor;

    // Start is called before the first frame update
    void Start()
    {
        slingshot = GetComponentInChildren<Slingshot>();
        slingshot.forceStrength = slingshotForce;

        IsLit = startLit;
    }

    public void HitLights()
    {
        foreach(Flasher f in hitLights)
        {
            f.Flash(hitColor, 0.1f);
        }
    }
}
