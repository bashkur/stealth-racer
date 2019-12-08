using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public static bool paused = false;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                resume_game();
            } else
            {
                pause_game();
            }
        }
    }

    public void resume_game()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void pause_game()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void load_menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void quit_game()
    {
        Application.Quit();
    }
}
