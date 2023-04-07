using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuSceneLoader : MonoBehaviour
{
    public void LoadWeel()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadAurelien()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadBaptiste()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadEmilien()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadThomas()
    {
        SceneManager.LoadScene(5);
    }
}
