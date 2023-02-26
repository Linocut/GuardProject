using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject main;
    public GameObject credits;
    public GameObject controls;

    private void Awake()
    {
        main.SetActive(true);
        credits.SetActive(false);
        controls.SetActive(false);
    }

    private void Start()
    {
        main.SetActive(true);
        credits.SetActive(false);
        controls.SetActive(false);
    }
    
    private void update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void SeeCreditsMenu()
    {
        main.SetActive(false);
        credits.SetActive(true);
        controls.SetActive(false);
    }

    public void SeeControlMenu()
    {
        main.SetActive(false);
        credits.SetActive(false);
        controls.SetActive(true);
    }

    public void Back ()
    {
        main.SetActive(true);
        credits.SetActive(false);
        controls.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
