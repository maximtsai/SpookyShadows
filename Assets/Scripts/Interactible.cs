using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    // Start is called before the first frame update
    //Collider m_ObjectCollider;
    public GameObject letter;
    private bool isHovered = false;
    void Start()
    {
        //m_ObjectCollider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other) {
        letter.SetActive(true);
        isHovered = true;
        Debug.Log("Heya");
    }
    void OnTriggerExit(Collider other) {
        // Destroy everything that leaves the trigger
        letter.SetActive(false);
        isHovered = false;
        Debug.Log("Outta");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && isHovered)
        {
            Destroy(gameObject);
        }
    }
}
