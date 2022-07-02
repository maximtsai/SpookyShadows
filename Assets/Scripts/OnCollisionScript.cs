using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string colliderName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        EventManager.TriggerEvent("enteredCollider", colliderName);
    }
}
