using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowArmScript : MonoBehaviour
{
    // Start is called before the first frame update
    private MeshRenderer mesh;
    void Start()
    {
        EventManager.StartListening("lightsOut", showArm);
        mesh = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void showArm(string name) {
        mesh.enabled = true;
    }
}
