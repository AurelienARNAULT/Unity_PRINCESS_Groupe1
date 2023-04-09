using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    // Le nom de la scène à charger lorsque la porte est traversée


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Doors"))
        {
            SceneManager.LoadScene(0);
        }
    }
}