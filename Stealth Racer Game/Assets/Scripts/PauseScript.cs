using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public static bool paused = false;

    public GameObject pauseMenu;
    public GameObject C1;
    public GameObject C2;
    public GameObject C3;
    public GameObject C4;
    public GameObject C5;
    public GameObject Car;

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

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (CheckpointScript.currentCheckpoint == 0)
            {
                Car.transform.position = C1.transform.position;
                Car.transform.rotation = new Quaternion(0, -15, 0, 180);
            }
            else if (CheckpointScript.currentCheckpoint == 1)
            {
                Car.transform.position = C2.transform.position;
                Car.transform.rotation = new Quaternion(0, -130, 0, 180);
            }
            else if (CheckpointScript.currentCheckpoint == 2)
            {
                Car.transform.position = C3.transform.position;
                Car.transform.rotation = new Quaternion(0, -420, 0, 180);
            }
            else if (CheckpointScript.currentCheckpoint == 3)
            {
                Car.transform.position = C4.transform.position;
                Car.transform.rotation = new Quaternion(0, 450, 0, 180);
            }
            else if (CheckpointScript.currentCheckpoint == 4)
            {
                Car.transform.position = C5.transform.position;
                Car.transform.rotation = new Quaternion(0, 120, 0, 180);
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
