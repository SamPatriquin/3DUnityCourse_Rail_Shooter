using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float xSpeed = 4f;
    [SerializeField] float ySpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float xOffset = Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime;
        float yOffset = Input.GetAxis("Vertical") * ySpeed * Time.deltaTime;

        float xMove = Mathf.Clamp(xOffset + transform.localPosition.x, -5f, 5f);
        float yMove = Mathf.Clamp(yOffset + transform.localPosition.y, -3, 3);
        transform.localPosition = new Vector3(xMove, yMove, transform.localPosition.z);
    }
}
