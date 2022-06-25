using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject overlay;
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
    private float closeDelayMax = 25f;
    private bool dimLights = false;
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
        if (dimLights) {
            globalLight.intensity -= 0.004f * Time.fixedDeltaTime;
            playerLight.intensity = 2.25f - globalLight.intensity * 4.25f;
            globalLight.color = new Color(globalLight.intensity * 2f, globalLight.intensity * 2f, globalLight.intensity * 1f + 0.45f, 1f);

            if (globalLight.intensity < 0.08f) {
                playerLight.intensity = 2.25f;
                globalLight.color = new Color(0.1f, 0.1f, 0.5f, 1f);
                dimLights = false;
            }
        }
    }

    void handleShowOverlay(string name) {
        closeDelay = closeDelayMax;
        overlay.SetActive(true);
    }

    void handleHideOverlay(string name) {
        overlay.SetActive(false);
    }

    void handleLightsOut(string name) {
        dimLights = true;
        globalLight.intensity = 0.5f;
        //globalLight.intensity = Mathf.Lerp(0.75f, 0.1f, 3f);
        // globalLight.color = new Color(1f, 1f, 1f, 1f);
    }

    void handleGatheredPiece(string name) {
        switch(name) {
            case "A":
                portraitA.SetActive(false);
            break;  
            case "B":
                portraitB.SetActive(false);
            break;
            case "C":
                portraitC.SetActive(false);
            break;
            case "D":
                portraitD.SetActive(false);
            break;
            case "E":
                portraitE.SetActive(false);
            break;
            case "F":
                portraitF.SetActive(false);
            break;
            case "G":
                portraitG.SetActive(false);
            break;
        }
    }
}
