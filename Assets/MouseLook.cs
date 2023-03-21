using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
   public float sensitivity = 200.0f;
public float clampAngle = 80.0f;

private float rotY = 0.0f; // rotation around the y-axis
private float rotX = 0.0f; // rotation around the x-axis

void Start()
{
    Vector3 rot = transform.localRotation.eulerAngles;
    rotY = rot.y;
    rotX = rot.x;
}

void Update()
{
    float mouseX = Input.GetAxis("Mouse X");
    float mouseY = -Input.GetAxis("Mouse Y");

    rotY += mouseX * sensitivity * Time.deltaTime;
    rotX += mouseY * sensitivity * Time.deltaTime;

    rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

    Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
    transform.localRotation = localRotation;
}
}
