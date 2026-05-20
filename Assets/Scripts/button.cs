using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine;

public class button : MonoBehaviour
{

    public bool hover = false;

    private void Update()
    {
        if(hover == true && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if(this.name == "Play")
            {
                MainMenu.PlayGame();
            }
            else if (this.name == "Sound")
            {
                MainMenu.ToggleSound();
            }
            else if (this.name == "Options")
            {
                MainMenu.OpenOptions();
            }
            else if (this.name == "Info")
            {
                MainMenu.OpenInfo();
            }
            else if (this.name == "Quit")
            {
                MainMenu.QuitGame();
            }
        }
    }

    private void OnMouseEnter()
    {
        hover = true;
    }

    private void OnMouseExit()
    {
        hover = false;
    }
}
