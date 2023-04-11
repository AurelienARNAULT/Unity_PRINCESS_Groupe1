using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("DoorTrigger");
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }
}