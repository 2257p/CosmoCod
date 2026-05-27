using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainMenu : MonoBehaviour
{


    private bool soundOn = true;

    public void Play()
    {
        SceneManager.LoadScene("CC Planet");
    }

    public void Option()
    {
        SceneManager.LoadScene("Setting");
    }

    public void Info()
    {
        SceneManager.LoadScene("Info");
    }

    public void Previous()
    {
        SceneManager.LoadScene("MAINMENU");
    }
    public void Quit()
    {
        Debug.Log("QUIT GAME");

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}