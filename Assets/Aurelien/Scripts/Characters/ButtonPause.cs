using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPause : MonoBehaviour
{
    public Button resume;
    public Button mainMenu;
    
    
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            resume.Select();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            mainMenu.Select();
        }
    }
}
