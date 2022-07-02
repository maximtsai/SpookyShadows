using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceTwoScript : MonoBehaviour
{
    public GameObject BloodStuff;
    public GameObject Eye;
    private bool isHovered = false;
    private bool isCollected = false;
    private bool showEye = false;
    void Start()
    {
        EventManager.StartListening("overlayJustClosed", handleHideOverlay);
    }

    void OnTriggerEnter(Collider other) {
        isHovered = true;
    }
    void OnTriggerExit(Collider other) {
        // Destroy everything that leaves the trigger
        isHovered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && isHovered)
        {
            isCollected = true;
            ScriptFunc();
            transform.position = new Vector3(999, 1, 0);
        }

        if (showEye) {

        }
    }

    void handleHideOverlay(string name) {
        if (isCollected) {
            Destroy(gameObject);
            // Destroy(BloodStuff);
            // Eye
        }
    }

    void ScriptFunc() {
        EventManager.TriggerEvent("gatheredPiece", "A");
        EventManager.TriggerEvent("showOverlay", " ");
    }
}
