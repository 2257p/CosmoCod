using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static bool isPaused = false;

    public GameObject PauseMenu;
    public GameObject DigitalClock;

    void Start()
    {
        PauseMenu.SetActive(false);
        DigitalClock.SetActive(true);

        Time.timeScale = 1f;
        isPaused = false;
    }

    void Update()
    {
        // ESC KEY PRESSED
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log("ESC PRESSED");

            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        DigitalClock.SetActive(false);

        Time.timeScale = 0f;
        isPaused = true;

        Debug.Log("GAME PAUSED");
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        DigitalClock.SetActive(true);

        Time.timeScale = 1f;
        isPaused = false;

        Debug.Log("GAME RESUMED");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;

        SceneManager.LoadScene("MAINMENU");
    }

    public static bool getIsPaused()
    {
        return isPaused;
    }

    public static double ReturnQuota(int days)
    {
        return Math.Ceiling(500 * Math.Pow(1.20, days));
    }

    public void SaveGame()
    {
        Debug.Log("GAME SAVED");

        // Add save system later
    }
}
