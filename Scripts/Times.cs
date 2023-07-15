using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Times : MonoBehaviour
{
    float timeInGame;
    int hour, minute, second;
    string hourText, minuteText, secondText;
    bool updateMinute, updateHour;
    [SerializeField] TextMeshProUGUI timer;

    // Start is called before the first frame update
    void Start()
    {
        hour = 0;
        minute = 0;
        second = 0;
        updateMinute = false;
        updateHour = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeInGame += Time.deltaTime;
        second = (int)timeInGame % 60;
        if(second == 0 && updateMinute)
        {
            if (updateHour)
            {
                hour++;
                minute = 0;
                second = 0;
                updateHour = false;
            } else
            {
                minute++;
                second = 0;
                updateMinute = false;
            }
        }

        if(second == 59)
        {
            updateMinute = true;
        }
        if(minute == 59 && second == 59)
        {
            updateHour = true;
        }
        hourText = leadingZero(hour);
        minuteText = leadingZero(minute);
        secondText = leadingZero(second);
        timer.SetText(hourText + " : " + minuteText + " : " + secondText);
    }

    string leadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}
