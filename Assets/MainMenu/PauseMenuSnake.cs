﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuSnake : MonoBehaviour
{
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Touche échap enfoncée");
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }

    public void resume()
    {
        Time.timeScale = 0.3f;
        pauseMenu.SetActive(false);
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }
}
