using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] GameObject[] guns;

    [Header("Speed")]
    [SerializeField] float xSpeed = 7f;
    [SerializeField] float ySpeed = 7f;

    [Header("Screen Bounds")]
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3f;

    [Header("Movement Tuning")]
    [SerializeField] float positionPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float dampeningPitch = -10f;
    [SerializeField] float dampeningRoll = -10f;

    float xThrow;
    float yThrow;
 

    bool isControllsEnabled = true;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (isControllsEnabled) {
            processTranslation();
            processRotation();
            processFiring();
        }
    }

    private void onPlayerDeath() { //Called from CollisionHandler
        isControllsEnabled = false;
    }

    private void processTranslation() {

        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float xMove = Mathf.Clamp(xOffset + transform.localPosition.x, -xRange, xRange);
        float yMove = Mathf.Clamp(yOffset + transform.localPosition.y, -yRange, yRange);
        transform.localPosition = new Vector3(xMove, yMove, transform.localPosition.z);
    }

    private void processRotation() {
        float pitch = positionPitchFactor * transform.localPosition.y + (yThrow * dampeningPitch);
        float yaw = positionYawFactor * transform.localPosition.x;
        float roll = xThrow * dampeningRoll;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void processFiring() {
        if (Input.GetButton("Fire")) {
            foreach (GameObject gun in guns) {
                var emmisionModule = gun.GetComponent<ParticleSystem>().emission;
                emmisionModule.enabled = true;
            }
        } else {
            foreach (GameObject gun in guns) {
                var emmisionModule = gun.GetComponent<ParticleSystem>().emission;
                emmisionModule.enabled = false;
            }
        }
    }
}
