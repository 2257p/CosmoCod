using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private static bool isPaused = false;
    public GameObject PauseMenu;
    public GameObject DigitalClock;
    void Start()
    {
        if (isPaused == false)
        {
            PauseMenu.SetActive(false);
        }
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame || Keyboard.current.pKey.wasPressedThisFrame)
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        DigitalClock.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        DigitalClock.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }  

    public static bool getIsPaused()
    {
        return isPaused;
    }
    
    public static double ReturnQuota(int days)
    {
        return Math.Ceiling(500 * Math.Pow(1.20, days));
    }
}
