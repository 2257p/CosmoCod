using UnityEngine;
using TMPro;

public class QuotaDisplay : MonoBehaviour
{
    GameManager gm;
    TimeManager tm;
    TextMeshProUGUI display;

    void Start()
    {
        tm = Object.FindFirstObjectByType<TimeManager>();
        // find QuotaText specifically by name instead
        display = transform.Find("QuotaText").GetComponent<TextMeshProUGUI>();

        if (tm == null) Debug.LogError("TimeManager not found!", this);
        if (display == null) Debug.LogError("QuotaText not found!", this);
    }

    void Update()
    {
        if (tm != null && display != null)
        {
            double quota = GameManager.ReturnQuota(tm.GetDayCount());
            display.text = "Day " + tm.GetDayCount() + " Quota: $" + quota;
        }
    }
}