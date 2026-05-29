using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public const int hoursInDay = 24, minutesInHour = 60;

    public float dayDuration;

    float totalTime = 0;
    float currentTime = 0;

    private float timer = 0f;
    private int dayCount = 1;

    private bool isSunset = false;
    private bool isSunrise = false;
    private bool isNight = false;
    private bool isDay = false;

    void Update()
    {
        totalTime += Time.deltaTime;
        currentTime = totalTime % dayDuration;

        if (!GameManager.getIsPaused())
        {
            timer += Time.deltaTime;

            if (timer >= dayDuration)
            {
                timer -= dayDuration;
                dayCount++;
                // reset flags for new day
                isSunrise = false;
                isSunset = false;
                isNight = false;
                isDay = false;
            }
        }

        int hour = Mathf.FloorToInt(GetHour()); // whole number hour, 0-23

        if (hour == 6 && !isSunrise)
        {
            isSunrise = true;
            isNight = false;
            Debug.Log("its sunrise now");
        }

        if (hour == 8 && !isDay)
        {
            isDay = true;
            isSunrise = false;
            Debug.Log("its day time now");
        }

        if (hour == 18 && !isSunset)
        {
            isSunset = true;
            isDay = false;
            Debug.Log("its sunset now");
        }

        if (hour == 20 && !isNight)
        {
            isNight = true;
            isSunset = false;
            Debug.Log("its night time now");
        }
    }

    public float GetHour()
    {
        return currentTime * hoursInDay / dayDuration;
    }

    public float GetMinutes()
    {
        return (currentTime * hoursInDay * minutesInHour / dayDuration)%minutesInHour;
    }

    public string Clock24Hour()
    {
        return Mathf.FloorToInt(GetHour()).ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00");
    }

    public int GetDayCount()
    {
        return dayCount;
    }

    public float GetTimeElapsed()
    {
        return timer;
    }
}