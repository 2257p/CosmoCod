using UnityEngine;
using UnityEngine.UI;

public class BrightnessSlider : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image overlayPanel;

    [Header("Settings")]
    [SerializeField] private float minBrightness = 0f;
    [SerializeField] private float maxBrightness = 1f;

    private Slider brightnessSlider;

    void Start()
    {
        // Grab the Slider on this same GameObject
        brightnessSlider = GetComponent<Slider>();

        brightnessSlider.minValue = minBrightness;
        brightnessSlider.maxValue = maxBrightness;

        brightnessSlider.onValueChanged.AddListener(OnBrightnessChanged);

        float saved = PlayerPrefs.GetFloat("Brightness", maxBrightness);
        brightnessSlider.value = saved;
    }

    void OnBrightnessChanged(float value)
    {
        float alpha = 1f - value;
        overlayPanel.color = new Color(0, 0, 0, alpha);
        PlayerPrefs.SetFloat("Brightness", value);
    }

    void OnDestroy()
    {
        brightnessSlider.onValueChanged.RemoveListener(OnBrightnessChanged);
    }
}