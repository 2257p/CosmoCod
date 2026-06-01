using UnityEngine;

public class DayNightOverlay : MonoBehaviour
{
    TimeManager tm;
    CanvasGroup canvasGroup;

    void Start()
    {
        tm = Object.FindFirstObjectByType<TimeManager>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (tm == null) Debug.LogError("TimeManager not found!", this);
        if (canvasGroup == null) Debug.LogError("CanvasGroup not found!", this);
    }

    void Update()
    {
        if (tm == null || canvasGroup == null) return;

        int hour = Mathf.FloorToInt(tm.GetHour());

        // sunrise: hours 6-8, fade out (1 -> 0)
        if (hour >= 6 && hour < 8)
        {
            float t = (tm.GetHour() - 6f) / 2f; // 0 to 1 over 2 hours
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t);
        }
        // daytime: hours 8-18, fully transparent
        else if (hour >= 8 && hour < 18)
        {
            canvasGroup.alpha = 0f;
        }
        // sunset: hours 18-20, fade in (0 -> 1)
        else if (hour >= 18 && hour < 20)
        {
            float t = (tm.GetHour() - 18f) / 2f; // 0 to 1 over 2 hours
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, t);
        }
        // night: hours 20-6, fully opaque
        else
        {
            canvasGroup.alpha = 1f;
        }
    }
}