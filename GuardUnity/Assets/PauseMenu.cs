using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenu;
    public GameObject resume, menu, quit;
    void Update()
    {
        
        if (Input.GetButtonDown("Pause"))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();   
            }
        }
    }

    public void Resume ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause ()
    {
    

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resume);
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void GoToMainMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
        GamePaused = false;
    }

    public void QuitGame()
    {
        
        Application.Quit();
    }
}
