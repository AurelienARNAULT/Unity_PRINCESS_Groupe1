using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float moveSpeed = 0.05f; // Vitesse de déplacement de la caméra
    public float rotateSpeed = 10f; // Vitesse de rotation de la caméra
    public float distanceFromGround = 10f; // Distance de la caméra par rapport au sol

    private float originalDistanceFromGround;
    private Rigidbody rb;

    void Start()
    {
        // Calcul de la distance entre la caméra et le sol
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity))
        {
            distanceFromGround = hit.distance + 0.5f;
        }

        originalDistanceFromGround = distanceFromGround;

        // Ajout du Rigidbody
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
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
            float heightCorrection = originalDistanceFromGround - groundDistance;
            transform.position += new Vector3(0, heightCorrection, 0);
        }
        

        // Rotation de la caméra
        float rotate = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        transform.Rotate(0, rotate, 0);

        // Vérification de la collision avec un mur
        RaycastHit wallHit;
        if (Physics.Raycast(transform.position, transform.forward, out wallHit, 0.1f))
        {
            if (wallHit.collider.CompareTag("Untagged"))
            {
                // Inverse le mouvement de la caméra en cas de collision avec un mur
                transform.position -= moveDirection * moveSpeed * Time.deltaTime;
            }
        }
       float horizontalMouse = Input.GetAxis("Mouse X");
Vector3 sidewaysDirection = new Vector3(horizontalMouse, 0, 0);
sidewaysDirection = transform.TransformDirection(sidewaysDirection);
if (Physics.Raycast(transform.position, sidewaysDirection, out wallHit, 0.5f))
{
    if (wallHit.collider.CompareTag("Untagged"))
    {
        // Inverse le mouvement de la caméra en cas de collision avec un mur
        transform.position -= sidewaysDirection * moveSpeed * Time.deltaTime;
    }
}
    }
}