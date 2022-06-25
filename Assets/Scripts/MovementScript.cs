using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float moveSpeed = 6;
    public Rigidbody PlayerRigid { get; private set; }
    public float cameraHeight = 10;

    private void Awake()
    {
        PlayerRigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Grabbing User Input
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //float rotInput = Input.GetAxis("Mouse X") * Time.fixedDeltaTime * rotSpeed;
        //cameraOffset += Input.GetAxis("Mouse Y") * Time.fixedDeltaTime * rotSpeed;

        // Rotating a Moving Player
        //PlayerRigid.rotation *= Quaternion.Euler(0, rotInput, 0);
        PlayerRigid.position += PlayerRigid.rotation * moveInput.normalized * moveSpeed * Time.fixedDeltaTime;

        // Snapping Camera to Head
        //Camera.main.transform.rotation = PlayerRigid.rotation * Quaternion.Euler(cameraOffset, 0, 0);
        Camera.main.transform.position = transform.position + new Vector3(0, cameraHeight, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
