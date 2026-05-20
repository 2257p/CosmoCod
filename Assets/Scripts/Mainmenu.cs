using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // SOUND BUTTON TEXT
    public static Text soundText;

    private static bool soundOn = true;

    // PLAY BUTTON
    public static void PlayGame()
    {
        SceneManager.LoadScene("vincenttests");
    }

    // OPTIONS BUTTON
    public static void OpenOptions()
    {
        Debug.Log("OPTIONS");
    }

    // INFO BUTTON
    public static void OpenInfo()
    {
        SceneManager.LoadScene("INFO");
    }

    // SOUND BUTTON
    public static void ToggleSound()
    {
        soundOn = !soundOn;

        AudioListener.volume = soundOn ? 1 : 0;

        if (soundOn)
        {
            soundText.text = "SOUND: ON";
        }
        else
        {
            soundText.text = "SOUND: OFF";
        }
    }

    // QUIT BUTTON
    public static void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
}