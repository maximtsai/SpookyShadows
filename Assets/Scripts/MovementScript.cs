using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float moveSpeed = 6;
    private Rigidbody PlayerRigid;
    public Transform PlayerRotateBody;
    public float cameraHeight = 10;

    private float inertiaCounter = 0;
    private float inertiaBreakpoint = 0.25f;
    private bool isPressingUp = false;
    private bool isPressingDown = false;
    private bool isPressingRight = false;
    private bool isPressingLeft = false;
    private bool isPressingRun = false;

    private Vector2 mousePos;
    private Vector2 mouseUnitDir;
    private float goalAngle = 0;
    private float angleRotSpd = 0;
    private float angleShake = 0;
    private float playerBodyRot = 0;
    private float minMoveAmt = 1f;
    private float minMoveTracker = 0;

    private bool canMove = true;

    private void Awake()
    {
        PlayerRigid = GetComponent<Rigidbody>();
        mousePos = new Vector2(0, 0);
        mouseUnitDir = new Vector2(0, 0);
        playerBodyRot = PlayerRotateBody.rotation.y;
    }

    private void Start() 
    {
        EventManager.StartListening("pauseMovement", disableMovement);
        EventManager.StartListening("resumeMovement", enableMovement);
        EventManager.StartListening("showOverlay", disableMovement);
        EventManager.StartListening("hideOverlay", enableMovement);
    }

    void disableMovement(string name) {
        canMove = false;
        PlayerRigid.velocity = Vector3.zero;
    }

    void enableMovement(string name) {
        canMove = true;
    }

    void Update() {
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            if (!isPressingUp) {
                inertiaCounter = inertiaBreakpoint * 0.4f;
            }
            isPressingUp = true;
        } else if (minMoveTracker > minMoveAmt) {
            isPressingUp = false;
        }

        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            if (!isPressingDown) {
                inertiaCounter = inertiaBreakpoint * 0.4f;
            }
            isPressingDown = true;
        } else if (minMoveTracker > minMoveAmt){
            isPressingDown = false;
        }

        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            if (!isPressingLeft) {
                inertiaCounter = inertiaBreakpoint * 0.4f;
            }
            isPressingLeft = true;
        } else if (minMoveTracker > minMoveAmt){
            isPressingLeft = false;
        }

        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            if (!isPressingRight) {
                inertiaCounter = inertiaBreakpoint * 0.4f;
            }
            isPressingRight = true;
        } else if (minMoveTracker > minMoveAmt){
            isPressingRight = false;
        }
        if (isPressingUp || isPressingRight || isPressingLeft || isPressingDown) {
            minMoveTracker += Time.fixedDeltaTime;
        } else {
            minMoveTracker = 0;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isPressingRun = true;
        } else {
            isPressingRun = false;
        }

        mousePos = Input.mousePosition;
        mouseUnitDir = new Vector2(mousePos.x - Screen.width * 0.5f, mousePos.y - Screen.height * 0.5f);
        goalAngle = Mathf.Atan2(mouseUnitDir.x, mouseUnitDir.y);// * 57.295f;
    }

    private void FixedUpdate()
    {
        if (!canMove) {
            return;
        }
        Vector3 moveInput = new Vector3(0, 0, 0);
        if (isPressingUp) {
            moveInput += new Vector3(0, 0, 1);
        } else if (isPressingDown) {
            moveInput += new Vector3(0, 0, -1);
        }
        if (isPressingLeft) {
            moveInput += new Vector3(-1, 0,0);
        } else if (isPressingRight) {
            moveInput += new Vector3(1, 0,0);
        }

        if (isPressingDown || isPressingUp || isPressingLeft || isPressingRight) {
            inertiaCounter += Time.fixedDeltaTime;
        } else if (inertiaCounter > inertiaBreakpoint) {
            inertiaCounter = inertiaBreakpoint * 0.75f;
        } else {
            inertiaCounter = Mathf.Max(0, inertiaCounter - Time.fixedDeltaTime);
        }

        float inertiaMult = inertiaCounter > inertiaBreakpoint ? 1 : 0.75f;

        float runSpeed = isPressingRun && inertiaCounter > inertiaBreakpoint ? 1.5f : 1f;

        // Rotating a Moving Player
        //PlayerRigid.rotation *= Quaternion.Euler(0, rotInput, 0);
        PlayerRigid.AddForce(moveInput.normalized * moveSpeed * runSpeed * inertiaMult * Time.fixedDeltaTime);

        // Snapping Camera to Head
        //Camera.main.transform.rotation = PlayerRigid.rotation * Quaternion.Euler(cameraOffset, 0, 0);
        Camera.main.transform.position = transform.position + new Vector3(0, cameraHeight, 0);

        float angleDiff = goalAngle * 57.296f - playerBodyRot;
        while (angleDiff > 180f) {
            angleDiff -= 360f;
            playerBodyRot += 360f;
        } 
        while (angleDiff < -180f) {
            angleDiff += 360f;
            playerBodyRot -= 360f;
        }

        angleShake = angleShake * 0.995f + Random.Range(-0.02f, 0.02f);
        angleRotSpd += angleDiff * 1.2f * Time.fixedDeltaTime - angleRotSpd * 0.2f + angleShake;

        playerBodyRot = playerBodyRot + angleRotSpd;
        PlayerRotateBody.rotation = Quaternion.Euler(0, playerBodyRot, 0);
    }
}
