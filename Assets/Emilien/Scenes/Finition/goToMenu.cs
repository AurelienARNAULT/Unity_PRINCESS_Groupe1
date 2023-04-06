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
        btn = GameObject.Find("Button").GetComponent<Button>();
        btn.onClick.AddListener(ButtonSelected);
    }

    public void ButtonSelected(){
        allerAuNiveau();
        
    }

    public void allerAuNiveau(){
        SceneManager.LoadScene(0);
    }
}
