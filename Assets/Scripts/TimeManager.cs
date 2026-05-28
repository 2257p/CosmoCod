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
    private int dayCount = 0;

    private bool isSunset = false;
    private bool isSunrise = false;
    private bool isNight = false;
    private bool isDay = false;



    // Update is called once per frame
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
            }
        }

        if (currentTime >= (dayDuration * 6f / 24f) && isSunrise == false)
        {
            isSunrise = true;
            isNight = false;
            Debug.Log("its sunrise now");
        }

        if (currentTime >= (dayDuration * 8f / 24f) && isDay == false)
        {
            isDay = true;
            isSunrise = false;
            Debug.Log("its day time now");
        }

        if (currentTime >= (dayDuration * 18f / 24f) && isSunset == false)
        {
            isSunset = true;
            isDay = false;
            Debug.Log("its sunset now");
        }

        if (currentTime >= (dayDuration * 20f / 24f) && isNight == false)
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