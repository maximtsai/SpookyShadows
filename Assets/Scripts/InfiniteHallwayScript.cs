using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteHallwayScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool shouldTeleport = false;
    private float cameraHeight = 10;
    private GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldTeleport) {
            Transform playerBody = player.transform.GetChild(0);
            if(playerBody.rotation.y < 0.95f && playerBody.rotation.y > -0.95f) {
                player.transform.Translate(0, 0, -4.0f);
                Camera.main.transform.position = player.transform.position + new Vector3(0, cameraHeight, -0.1f);
                shouldTeleport = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            player = other.gameObject;
            shouldTeleport = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        shouldTeleport = false;
    }
}
