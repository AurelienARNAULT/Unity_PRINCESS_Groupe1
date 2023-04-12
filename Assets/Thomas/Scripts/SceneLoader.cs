using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadMenu()
    {
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene(0);
    }
}
