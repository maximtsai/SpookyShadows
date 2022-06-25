using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceOneScript : MonoBehaviour
{
    private bool isHovered = false;
    public GameObject fence;
    public GameObject lightSource;
    void Start()
    {

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
            ScriptFunc();
            Destroy(gameObject);
        }
    }

    void ScriptFunc() {
        EventManager.TriggerEvent("gatheredPiece", "START");
        EventManager.TriggerEvent("showOverlay", "");
        EventManager.TriggerEvent("lightsOut", "");
        Destroy(fence);
    }
}
