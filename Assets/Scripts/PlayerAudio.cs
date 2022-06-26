using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource sourceSfx;
    public AudioClip epiphany1;
    public AudioClip epiphany2;
    public AudioClip epiphany3;
    void Start()
    {
        // sourceSfx.Play();
        EventManager.StartListening("gatheredPiece", handleGatheredPiece);

    }

    // Update is called once per frame
    void Update()
    {
    }

    void handleGatheredPiece(string name) {
        float randVal = Random.Range(0f, 1f);
        if (randVal < 0.33f) {
            sourceSfx.PlayOneShot(epiphany1, 1f);
        } else if (randVal < 0.66f) {
            sourceSfx.PlayOneShot(epiphany2, 1f);
        } else {
            sourceSfx.PlayOneShot(epiphany3, 1f);
        }
    }
}
