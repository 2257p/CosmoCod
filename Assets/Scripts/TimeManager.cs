using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public const int hoursInDay = 24, minutesInHour = 60;

    public float dayDuration;

    static float totalTime = 0;
    float currentTime = 0;

    static private float timer = 0f;
    static private int dayCount = 1;

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

                isSunrise = false;
                isSunset = false;
                isNight = false;
                isDay = false;

                double quota = GameManager.ReturnQuota(dayCount);


                if (Inventory.money >= quota)
                {
                    Debug.Log("this should display if the player passes the quota");
                    Inventory.money -= (float)quota;
                }
                else
                {
                    Debug.Log("this message should display if the player doesnt meet quota please work");
                    MainMenu.GameOver();
                }

            }
        }

        int hour = Mathf.FloorToInt(GetHour());

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