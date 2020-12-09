﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void ToGame() 
    {
        SceneManager.LoadScene(1);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit ()
    {
        Application.Quit();
    }
}
