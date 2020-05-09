using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float xSpeed = 4f;
    [SerializeField] float ySpeed = 4f;

    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;

    float xOffset;
    float yOffset;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;
   

    [SerializeField] float dampeningPitch = -5f;
    [SerializeField] float dampeningRoll = -20f;

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
        xOffset = Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime;
        yOffset = Input.GetAxis("Vertical") * ySpeed * Time.deltaTime;

        float xMove = Mathf.Clamp(xOffset + transform.localPosition.x, -xRange, xRange);
        float yMove = Mathf.Clamp(yOffset + transform.localPosition.y, -yRange, yRange);
        transform.localPosition = new Vector3(xMove, yMove, transform.localPosition.z);
    }

    private void ProcessRotation() {
        float pitch = (positionPitchFactor * transform.localPosition.y + (yOffset * dampeningPitch)) - 90;
        float yaw = positionYawFactor * transform.localPosition.x;
        float roll = 90;

        transform.localRotation = Quaternion.Euler(90, 0, 0);
    }
}
