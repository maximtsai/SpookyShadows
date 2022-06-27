using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassScript : MonoBehaviour
{
    private bool isHovered = false;
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
            EventManager.TriggerEvent("gatheredPiece", "COMPASS");
            Destroy(gameObject);
        }
    }
}
