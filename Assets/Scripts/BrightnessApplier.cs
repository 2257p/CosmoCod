using UnityEngine;
using UnityEngine.UI;

public class BrightnessApplier : MonoBehaviour
{
    
    void Start()
    {
        float brightness = PlayerPrefs.GetFloat("Brightness", 1f);
        GetComponent<Image>().color = new Color(0, 0, 0, 1f - brightness);
    }
}