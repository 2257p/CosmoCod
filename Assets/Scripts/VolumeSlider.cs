using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider slider;
    private AudioSource audio;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.minValue = 0f;
        slider.maxValue = 1f;
        audio = MusicManager.Instance.GetComponent<AudioSource>();
        slider.value = PlayerPrefs.GetFloat("Volume", 0.5f); // load saved value
        slider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float value)
    {
        audio.volume = value * value;
        PlayerPrefs.SetFloat("Volume", value); // save it
    }

    void OnDestroy() { slider.onValueChanged.RemoveListener(OnVolumeChanged); }
}