using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float moveSpeed = 1f; // Vitesse de déplacement de la caméra
    public float rotateSpeed = 20f; // Vitesse de rotation de la caméra
    public float distanceFromGround = 10f; // Distance de la caméra par rapport au sol

    void Start()
    {
        // Calcul de la distance entre la caméra et le sol
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity))
        {
            distanceFromGround = hit.distance + (float)0.5;
        }
        
        // Ajout du Rigidbody
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
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
            float heightCorrection = distanceFromGround - groundDistance;
            transform.position += new Vector3(0, heightCorrection, 0);
        }

        // Rotation de la caméra
        float rotate = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        transform.Rotate(0, rotate, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
{
    // Inverse le mouvement de la caméra en cas de collision avec un mur
    transform.position -= collision.contacts[0].normal * moveSpeed * Time.deltaTime;
}
    }
}