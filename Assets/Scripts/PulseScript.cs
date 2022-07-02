using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseScript : MonoBehaviour
{
    // Start is called before the first frame update
    float startScale = 1;
    float currScale = 1;
    float scaleVel = 0;
    int delayCounter = 0;
    bool pauseRun = true;
    void Start()
    {
        startScale = transform.localScale.x;
        currScale = startScale;
        EventManager.StartListening("beginPulse", startPulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startPulse(string name) {
        pauseRun = false;
    }

    void FixedUpdate()
    {
        // Heartbeat like code
        if (pauseRun) {
            return;
        }
        if (delayCounter == -999) {
            currScale += scaleVel;
            scaleVel -= 0.0001f;
            if (currScale < startScale) {
                currScale = startScale;
                delayCounter = 30;
            }
            transform.localScale = new Vector3(currScale, 1, currScale);
        } else if (delayCounter <= 0) {
            scaleVel = 0.001f;
            delayCounter = -999;
        } else {
            delayCounter--;
        }
    }
}
