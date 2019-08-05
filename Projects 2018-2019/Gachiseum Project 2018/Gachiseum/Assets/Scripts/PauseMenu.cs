using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject camera;
    public GameObject pauseMenuUI;

    public bool titles;
    

    // Use this for initialization
    void Start()
    {
        if(!titles)
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!titles)
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            } else
            {
                Application.LoadLevel(0);
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        //player.GetComponent<CameraBobbing>().enabled = true;
        GetComponent<CameraController>().enabled = true;
        camera.GetComponent<CameraController>().enabled = true;
        GetComponent<PlayerMovement>().enabled = true;
        Time.timeScale = 1f;
        GameIsPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        //player.GetComponent<CameraBobbing>().enabled = false;
        GetComponent<CameraController>().enabled = false;
        camera.GetComponent<CameraController>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        Time.timeScale = 0f;
        GameIsPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Menu()
    {
        Application.LoadLevel(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
