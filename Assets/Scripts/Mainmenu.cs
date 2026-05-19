using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // SOUND BUTTON TEXT
    public Text soundText;

    bool soundOn = true;

    // PLAY BUTTON
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // OPTIONS BUTTON
    public void OpenOptions()
    {
        Debug.Log("OPTIONS");
    }

    // INFO BUTTON
    public void OpenInfo()
    {
        Debug.Log("INFO");
    }

    // SOUND BUTTON
    public void ToggleSound()
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
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
}