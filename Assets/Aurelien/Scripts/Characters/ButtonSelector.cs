using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSelector : MonoBehaviour
{
    public Button restart;
    public Button mainMenu;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            restart.Select();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            mainMenu.Select();
        }
    }
}