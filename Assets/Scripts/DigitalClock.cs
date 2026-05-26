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

// public class Program
// {
//     public static int CountDays(int days1)
//     {
//         if (days1 == 0)
//         {
//           return 0;
//         }
//         else if (days1 == 1)
//         {
//           return 1;
//         }
//         else
//         {
//           return 1 + CountDays(days1 - 1);
//         }
//     }

//     public static void Main(string[] args)
//     {
//         Console.WriteLine(CountDays(5));
//     }
// }
}