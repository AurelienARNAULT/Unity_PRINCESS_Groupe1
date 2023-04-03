using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float moveSpeed = 10f; // Vitesse de déplacement de la caméra
    public float rotateSpeed = 100f; // Vitesse de rotation de la caméra

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 2, -10);
    }

    void Update()
    {
        // Déplacement horizontal de la caméra
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontal, 0, 0) * moveSpeed * Time.deltaTime);

        float translation = Input.GetAxis("Vertical") * moveSpeed;
        translation *= Time.deltaTime;
        transform.Translate(0, 0, translation);

        /*// Rotation de la caméra
        float rotate = Input.GetAxis("Rotate");
        transform.Rotate(new Vector3(0, rotate, 0) * rotateSpeed * Time.deltaTime);
        */
    }
}
