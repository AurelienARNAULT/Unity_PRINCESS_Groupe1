using System.Collections;
using System.Collections.Generic;
using UnityEngine;


   public class MouseLock : MonoBehaviour
{
    private bool isMouseLocked = true;

    // Start is called before the first frame update
    void Start()
    {
        LockMouse();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockMouse();
        }
    }

    void LockMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isMouseLocked = true;
    }

    void UnlockMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isMouseLocked = false;
    }
}

