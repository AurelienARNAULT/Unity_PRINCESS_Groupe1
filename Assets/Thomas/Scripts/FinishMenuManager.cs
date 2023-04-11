using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenuManager : MonoBehaviour
{
    public TextMeshProUGUI finishText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart()
    {
        SceneManager.LoadScene(4);
    }
    
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void updateFinishText(string message)
    {
        finishText.text = message;
    }
}
