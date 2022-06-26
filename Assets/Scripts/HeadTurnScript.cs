using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTurnScript : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 mouseUnitDir;
    private float goalAngle = 0;
    private float currAngle = 0;
    private float angleRotSpd = 0;
    public Transform bodyTransform;
    private void Awake()
    {
        mousePos = new Vector2(0, 0);
        mouseUnitDir = new Vector2(0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mouseUnitDir = new Vector2(mousePos.x - Screen.width * 0.5f, mousePos.y - Screen.height * 0.5f);
        goalAngle = Mathf.Atan2(mouseUnitDir.x, mouseUnitDir.y) * 57.295f;
    }
    private void FixedUpdate()
    {

    }

}
