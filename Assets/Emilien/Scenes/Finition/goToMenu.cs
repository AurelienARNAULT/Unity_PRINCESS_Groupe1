using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class goToMenu : MonoBehaviour
{
    public Button btn;
    public string levelToLoad;

    public void start(){
        Time.timeScale = 1f;
        btn = GameObject.Find("Button").GetComponent<Button>();
        btn.onClick.AddListener(ButtonSelected);
    }

    public void ButtonSelected(){
        allerAuNiveau();
        
    }

    public void allerAuNiveau(){
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene(0);
    }
}
