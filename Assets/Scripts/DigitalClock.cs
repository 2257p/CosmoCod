using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DigitalClock : MonoBehaviour
{
    TimeManager tm;
    TextMeshProUGUI display;
    public int days;
    public bool _24HourClock = true;

    void Start()
    {
        tm = Object.FindFirstObjectByType<TimeManager>();
        display = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if (tm != null && display != null)
        {
            days = tm.GetDayCount();
            display.text = "Day " + days + "  " + tm.Clock24Hour();
        }
    }
}