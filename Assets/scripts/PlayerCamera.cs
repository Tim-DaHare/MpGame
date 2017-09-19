using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    float mouseCurrentX;
    float mouseCurrentY;

    [SerializeField]
    float cameraDistance;

    [SerializeField]
    Transform lookAt;

    // Update is called once per frame
    void LateUpdate () {
        mouseCurrentX += Input.GetAxis("Mouse X");
        mouseCurrentY -= Input.GetAxis("Mouse Y");

        //lookAt = transform.position + (Vector3.up * 1.7f);

        Vector3 cameraDirection = new Vector3(0, 0, -cameraDistance);
        Quaternion cameraRotation = Quaternion.Euler(mouseCurrentY, mouseCurrentX, 0);
        transform.position = lookAt.position + cameraRotation * cameraDirection;

        transform.LookAt(lookAt);
    }
}
