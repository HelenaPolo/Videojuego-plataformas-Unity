using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{


    public void GoToLevels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void GoToExit()
    {
        Application.Quit();
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
 
}
