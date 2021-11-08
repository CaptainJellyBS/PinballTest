using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawbridgeMission : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject drawBridge;
    public float _dropAngle = -80;
    public float _targetAngle = -120;
    public float currentPoint = 0.0f;
    bool isDown = false;

    Quaternion targetAngle, startAngle, dropAngle;

    void Start()
    {
        targetAngle = Quaternion.Euler(_targetAngle, 0, 0);
        dropAngle = Quaternion.Euler(_dropAngle, 0, 0);
        startAngle = drawBridge.transform.localRotation;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LowerBridge(float lower)
    {
        if (isDown) { return; }
        currentPoint += lower;

        drawBridge.transform.localRotation = Quaternion.Lerp(startAngle, dropAngle, currentPoint);

        if(currentPoint >= 1.0f)
        {
            isDown = true;
            StartCoroutine(DropBridge());
        }
    }

    IEnumerator DropBridge()
    {
        float t = 0;
        while (t <= 1.0f)
        {
            t += Time.deltaTime * 2;
            drawBridge.transform.localRotation = Quaternion.Lerp(dropAngle, targetAngle, t);
            yield return null;
        }

    }    
}
