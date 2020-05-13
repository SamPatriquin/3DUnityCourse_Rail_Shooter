using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header("Speed")]
    [SerializeField] float xSpeed = 7f;
    [SerializeField] float ySpeed = 7f;

    [Header("Screen Bounds")]
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3f;

    float xThrow;
    float yThrow;

    [Header("Movement Tuning")]
    [SerializeField] float positionPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 5f;
   

    [SerializeField] float dampeningPitch = -10f;
    [SerializeField] float dampeningRoll = -10f;

    bool isControllsEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update() {
        if (isControllsEnabled) {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    private void onPlayerDeath() { //Called from CollisionHandler
        isControllsEnabled = false;
    }

    private void ProcessTranslation() {

        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float xMove = Mathf.Clamp(xOffset + transform.localPosition.x, -xRange, xRange);
        float yMove = Mathf.Clamp(yOffset + transform.localPosition.y, -yRange, yRange);
        transform.localPosition = new Vector3(xMove, yMove, transform.localPosition.z);
    }

    private void ProcessRotation() {
        float pitch = positionPitchFactor * transform.localPosition.y + (yThrow* dampeningPitch);
        float yaw = positionYawFactor * transform.localPosition.x;
        float roll = xThrow * dampeningRoll;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
