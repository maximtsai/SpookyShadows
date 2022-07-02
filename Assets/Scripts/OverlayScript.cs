using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject title;
    public GameObject overlay;
    public GameObject compassHolder;
    public GameObject compass;
    public GameObject compassText;
    public GameObject needle;
    public GameObject portraitA;
    public GameObject portraitB;
    public GameObject portraitC;
    public GameObject portraitD;
    public GameObject portraitE;
    public GameObject portraitF;
    public GameObject portraitG;
    public Light globalLight;
    public Light playerLight;
    private float closeDelay = 0;
    private float closeDelayMax = 9f;
    private bool firstTimeClose = true;
    private bool gotCompass = false;
    void Start()
    {
        EventManager.StartListening("showOverlay", handleShowOverlay);
        EventManager.StartListening("hideOverlay", handleHideOverlay);
        EventManager.StartListening("lightsOut", handleLightsOut);
        EventManager.StartListening("gatheredPiece", handleGatheredPiece);

    }

    // Update is called once per frame
    void Update()
    {
        if (overlay.activeSelf && Input.anyKeyDown && closeDelay <= 0) {
            EventManager.TriggerEvent("hideOverlay", "");
        } else if (closeDelay > 0) {
            closeDelay -= Time.fixedDeltaTime;
        } 

        if (gotCompass && (Input.GetKeyDown("c") || Input.GetKeyDown("m"))) {
            if (compassHolder.activeSelf) {
                EventManager.TriggerEvent("resumeMovement", "");
                compassText.SetActive(false);
            } else {
                EventManager.TriggerEvent("pauseMovement", "");
            }
            compassHolder.SetActive(!compassHolder.activeSelf);
        }
        // if (dimLights) {
        //     globalLight.intensity -= 0.004f * Time.fixedDeltaTime;
        //     playerLight.intensity = 2.25f - globalLight.intensity * 4.25f;
        //     globalLight.color = new Color(globalLight.intensity * 2f, globalLight.intensity * 2f, globalLight.intensity * 1f + 0.45f, 1f);

        //     if (globalLight.intensity < 0.08f) {
        //         playerLight.intensity = 2.25f;
        //         globalLight.color = new Color(0.1f, 0.1f, 0.5f, 1f);
        //         dimLights = false;
        //     }
        // }
    }

    void handleShowOverlay(string name) {
        closeDelay = closeDelayMax;
        overlay.SetActive(true);
    }

    void handleHideOverlay(string name) {
        overlay.SetActive(false);
        if (firstTimeClose) {
            firstTimeClose = false;
            globalLight.intensity = 3f;
            EventManager.TriggerEvent("playSound", "Thunder");
            StartCoroutine(LightningSequence());
        }
        EventManager.TriggerEvent("overlayJustClosed", "");
    }

    IEnumerator LightningSequence()
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(0.1f);
        globalLight.intensity = 1f;
        yield return new WaitForSeconds(0.1f);
        globalLight.intensity = 0.25f;
        playerLight.intensity = 0.5f;
        yield return new WaitForSeconds(0.5f);
        globalLight.intensity = 3f;
        title.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        globalLight.intensity = 0.1f;
        playerLight.intensity = 5f;
        //Do the action after the delay time has finished.
        yield return new WaitForSeconds(3.5f);
        Destroy(title);
    }

    void handleLightsOut(string name) {
        // dimLights = true;
        globalLight.intensity = 0.5f;
        //globalLight.intensity = Mathf.Lerp(0.75f, 0.1f, 3f);
        // globalLight.color = new Color(1f, 1f, 1f, 1f);
    }

    void handleGatheredPiece(string name) {
        Debug.Log(name);
        switch(name) {
            case "COMPASS":
                EventManager.TriggerEvent("pauseMovement", "");
                compassHolder.SetActive(true);
                gotCompass = true;
                compass.SetActive(true);
            break; 
            case "A":
                Debug.Log("setactive");
                portraitA.SetActive(true);
            break;  
            case "B":
                portraitB.SetActive(true);
            break;
            case "C":
                portraitC.SetActive(true);
            break;
            case "D":
                portraitD.SetActive(true);
            break;
            case "E":
                portraitE.SetActive(true);
            break;
            case "F":
                portraitF.SetActive(true);
            break;
            case "G":
                portraitG.SetActive(true);
            break;
        }
    }
}
