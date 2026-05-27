using UnityEngine;
using UnityEngine.InputSystem;

public class SaveLoadTest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        SaveDetect();
        LoadDetect();
    }

    private void SaveDetect()
    {
        if (Keyboard.current[Key.S].wasPressedThisFrame)
        {
            SaveLoadFile.Save();
        }
    }

    private void LoadDetect()
    {
        if (Keyboard.current[Key.L].wasPressedThisFrame)
        {
            SaveLoadFile.Load();
        }
    }
}
