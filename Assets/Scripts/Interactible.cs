using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    // Start is called before the first frame update
    //Collider m_ObjectCollider;
    public GameObject letter;
    void Start()
    {

    }

    void OnTriggerEnter(Collider other) {
        letter.SetActive(true);
    }
    void OnTriggerExit(Collider other) {
        // Destroy everything that leaves the trigger
        letter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
