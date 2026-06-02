using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(OnVolumeChanged);
        if (MusicManager.Instance != null)
        {
            AudioSource audio = MusicManager.Instance.GetComponent<AudioSource>();
            if (audio != null)
                slider.value  = audio.volume;
        }
    }

    void OnVolumeChanged(float value)
    {
        if (MusicManager.Instance != null)
        {
            AudioSource audio = MusicManager.Instance.GetComponent<AudioSource>();
            if (audio != null)
                audio.volume = value;
        }
    }

    void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(OnVolumeChanged);
    }
}