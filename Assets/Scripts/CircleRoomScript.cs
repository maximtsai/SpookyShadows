using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRoomScript : MonoBehaviour
{
    // Start is called before the first frame update
        public bool isPressingDown = false;
        public GameObject portraitPiece;
        public GameObject blood1;
        public GameObject blood2;
        public GameObject blood3;
        public GameObject blood4;
        public GameObject blood5;
        public GameObject bloodF1;
        public GameObject bloodF2;
        public GameObject bloodF3;
        private int collision1Entries = 0;
        private int collision2Entries = 0;
        private int collision3Entries = 0;
        private int loopCount = 0;
    void Start()
    {
        EventManager.StartListening("enteredCollider", handleColliderEntered);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void handleColliderEntered(string name)
    {
        switch (name) {
            case "CircleOne":
                if (loopCount >= collision1Entries) {
                    collision1Entries = loopCount + 1;
                    if (collision1Entries == 1) {
                    } else if (collision1Entries == 2) {
                        blood4.SetActive(true);
                    } else if (collision1Entries == 3) {
                        bloodF1.SetActive(true);

                    }
                }
            break;
            case "CircleTwo":
                if (loopCount >= collision2Entries) {
                    collision2Entries = loopCount + 1;
                    if (collision2Entries == 1) {
                        blood1.SetActive(true);
                    } else if (collision2Entries == 2) {
                        blood3.SetActive(true);
                    } else if (collision2Entries == 3) {
                        bloodF2.SetActive(true);

                    }
                }
            break;
            case "CircleThree":
                if (loopCount >= collision3Entries) {
                    collision3Entries = loopCount + 1;
                    if (collision3Entries == 1) {
                        blood2.SetActive(true);
                    } else if (collision3Entries == 2) {
                        blood5.SetActive(true);

                    } else if (collision3Entries == 3) {
                        portraitPiece.SetActive(true);
                        bloodF3.SetActive(true);
                    }
                }
            break;
        }
        if (collision1Entries > loopCount && collision2Entries > loopCount && collision3Entries > loopCount) {
            loopCount += 1;
            Debug.Log(loopCount);
            if (loopCount == 3) {
                portraitPiece.SetActive(true);
            }
        }
    }

}
