using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceOneScript : MonoBehaviour
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
            ScriptFunc();
            Destroy(gameObject);
        }
    }

    void ScriptFunc() {

    }
}
