using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfDiamonds { get; private set; }

    public GameObject finishMenu;
    
    public UnityEvent<PlayerInventory> OnDiamondCollected;
    
    public int nbOfDiamonds = 3;


    public void Awake()
    {
        finishMenu.SetActive(false);
    }


    public void Update()
    {
        if (NumberOfDiamonds == nbOfDiamonds)
        {
            finishMenu.SetActive(true);
        }
    }

    public void DiamondCollected()
    {
        NumberOfDiamonds++;
        OnDiamondCollected.Invoke(this);
    }

    public void loadMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }

    public void loadRestart()
    {
        SceneManager.LoadScene(1);
    }
}