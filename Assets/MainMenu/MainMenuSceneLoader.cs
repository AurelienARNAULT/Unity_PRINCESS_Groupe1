using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuSceneLoader : MonoBehaviour
{
    
    public void LoadAurelien()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadBaptiste()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadEmilien()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadThomas()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadWeel()
    {
        SceneManager.LoadScene(7);
    }
}
