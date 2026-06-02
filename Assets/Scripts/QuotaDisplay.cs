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
 
        display = transform.Find("QuotaText").GetComponent<TextMeshProUGUI>();
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