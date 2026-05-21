using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    // DRAG YOUR SOUND BUTTON TEXT HERE
    public TMP_Text soundText;

    // SOUND STATE
    private bool soundOn = true;

    // PLAY BUTTON
    public void Play()
    {
        SceneManager.LoadScene("vincenttests");
    }

    // OPTIONS BUTTON
    public void Option()
    {
        SceneManager.LoadScene("Settings");
    }

    // INFO BUTTON
    public void Info()
    {
        SceneManager.LoadScene("INFO");
    }

    // BACK BUTTON (FROM INFO -> MAIN MENU)
    public void Previous()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // SOUND BUTTON
    public void Sound()
    {
        soundOn = !soundOn;

        // TURN AUDIO ON/OFF
        AudioListener.volume = soundOn ? 1f : 0f;

        // UPDATE BUTTON TEXT
        if (soundOn)
        {
            soundText.text = "SOUND: ON";
        }
        else
        {
            soundText.text = "SOUND: OFF";
        }

        Debug.Log("Sound: " + soundOn);
    }

    // QUIT BUTTON
    public void Quit()
    {
        Debug.Log("QUIT GAME");

        Application.Quit();

        // stops play mode in editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}