using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float xSpeed = 15f;
    [SerializeField] float ySpeed = 15f;

    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3f;

    float xThrow;
    float yThrow;

    [SerializeField] float positionPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 5f;
   

    [SerializeField] float dampeningPitch = -35f;
    [SerializeField] float dampeningRoll = -40f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update() {
        ProcessTranslation();
        ProcessRotation();
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
