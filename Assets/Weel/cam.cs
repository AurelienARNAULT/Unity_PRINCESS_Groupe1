using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float moveSpeed = 1f; // Vitesse de déplacement de la caméra
    public float rotateSpeed = 20f; // Vitesse de rotation de la caméra

    private float distanceFromGround; // Distance de la caméra par rapport au sol

    // Start is called before the first frame update
    void Start()
    {
        // Calcul de la distance entre la caméra et le sol
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity))
        {
            distanceFromGround = hit.distance;
        }
    }

    void Update()
    {
        // Déplacement horizontal de la caméra
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        moveDirection = transform.TransformDirection(moveDirection);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Correction de la hauteur de la caméra
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity))
        {
            float groundDistance = hit.distance;
            float heightCorrection = distanceFromGround - groundDistance;
            transform.position += new Vector3(0, heightCorrection, 0);
        }

        // Rotation de la caméra
        float rotate = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        transform.Rotate(0, rotate, 0);
    }
}