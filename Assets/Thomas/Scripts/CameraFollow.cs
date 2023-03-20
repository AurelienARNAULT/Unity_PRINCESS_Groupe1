using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 cameraOffset;
    public Vector3 cameraRotation;
    public float lookAheadDistance;

    private Vector3 previousPosition;
    private Vector3 previousMoveDirection;

    void Start()
    {
        previousPosition = player.transform.position;
        previousMoveDirection = player.transform.forward;
    }

    void LateUpdate()
    {
        // Récupère la direction de déplacement du joueur
        Vector3 moveDirection = (player.transform.position - previousPosition).normalized;
        previousPosition = player.transform.position;

        // Détermine si la voiture avance ou recule
        bool isMovingForward = Vector3.Dot(player.transform.forward, moveDirection) > 0f;

        // Utilise la direction de déplacement précédente si la voiture ne bouge pas
        if (moveDirection.magnitude == 0f)
        {
            moveDirection = previousMoveDirection;
            isMovingForward = true;
        }
        else
        {
            previousMoveDirection = moveDirection;
        }

        // Calcule la rotation de la caméra pour regarder vers l'avant ou l'arrière de la voiture
        Quaternion lookRotation = isMovingForward ? Quaternion.LookRotation(player.transform.forward, Vector3.up) * Quaternion.Euler(cameraRotation) :
            Quaternion.LookRotation(-player.transform.forward, Vector3.up) * Quaternion.Euler(cameraRotation);

        // Applique la rotation et le décalage de la caméra
        Vector3 rotatedOffset = lookRotation * cameraOffset;
        transform.position = player.transform.position + rotatedOffset;

        // Regarde vers l'avant ou l'arrière de la voiture
        Vector3 lookAtPosition = isMovingForward ? player.transform.position + (player.transform.forward * lookAheadDistance) :
            player.transform.position - (player.transform.forward * lookAheadDistance);
        transform.LookAt(lookAtPosition);
    }
}