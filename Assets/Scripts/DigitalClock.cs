using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DigitalClock : MonoBehaviour
{
    TimeManager tm;
    TextMeshProUGUI display; // ← change this

    public bool _24HourClock = true;

    void Start()
    {
        tm = Object.FindFirstObjectByType<TimeManager>();
        display = GetComponentInChildren<TextMeshProUGUI>(); // ← and this
    }

    void Update()
    {
        if (tm != null && display != null)
            display.text = tm.Clock24Hour();
    }
}