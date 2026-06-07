using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainMenu : MonoBehaviour
{
    private bool soundOn = true;

    public void Play()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void Option()
    {
        SceneManager.LoadScene("Setting");
    }

    public void Info()
    {
        SceneManager.LoadScene("INFO");
    }

    public void Previous()
    {
        SceneManager.LoadScene("MAINMENU");
    }
    
    public static void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    
    public void Quit()
    {
        Debug.Log("QUIT GAME");

        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}