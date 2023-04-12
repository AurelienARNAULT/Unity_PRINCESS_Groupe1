using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectWall : MonoBehaviour
{
    public float detectRange = 1.0f; // La distance de détection
    public LayerMask wallLayer; // Le layer qui représente les murs
    private bool sceneLoaded = false; // Variable booléenne pour suivre si la scène a été chargée 

    private void Update()
    {
        // Lance un rayon devant l'objet
        if(!sceneLoaded){
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, detectRange, wallLayer))
        {
            // Si le rayon a touché un mur, affiche un message dans la console
            Debug.Log("Attention, un mur est proche !");
            
            // Définir "sceneLoaded" sur "true"
            sceneLoaded = true;
        }
        }
        if(sceneLoaded){
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }
}
