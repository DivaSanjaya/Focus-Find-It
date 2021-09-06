﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void SelectLevel(int level)
    {
        SceneManager.LoadScene(level);

    }
    

    
}
