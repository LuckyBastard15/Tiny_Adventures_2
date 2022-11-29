using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject _pauseMenu;
    public GameObject _startMenu;
    public GameObject _MoveJoystick;
    public GameObject _CameraJoystick;
    public void StartButton()
    {
        
        SceneManager.LoadScene("Game1");
        Time.timeScale = 1;
    }

    public void ExitButton()
    {
       
        SceneManager.LoadScene("StartMenu");
    }

    public void RestartButton()
    {
        
        SceneManager.LoadScene("Game1");
        Time.timeScale = 1;
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        
        if (Time.timeScale == 1)
        {
            _pauseMenu.SetActive(false);
            _MoveJoystick.SetActive(true);
            _CameraJoystick.SetActive(true);
            
        }
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        if (Time.timeScale == 0)
        {
            _pauseMenu.SetActive(true);
            _MoveJoystick.SetActive(false);
            _CameraJoystick.SetActive(false);
        }
    }
}
