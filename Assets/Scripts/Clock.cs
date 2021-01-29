using TMPro;
using UnityEngine;
using TigerForge;


public class Clock : MonoBehaviour
{
    public TextMeshProUGUI[] UI_TIME_TEXT;
    public TextMeshProUGUI[] UI_DATE_TEXT;
    public TimeFormat timeFormat = TimeFormat.Hour_24;
    public DateFormat dateFormat = DateFormat.DD_MM_YYYY;
    public float secPerMin = 1 * GameSpeed.timeFactor;
    EasyFileSave saveSystem;

    private string _time;
    private string _date;

    private bool isAm;

    public int hr;
    public int min;

    public int day;
    public int month;
    public int year;

    int maxHr = 24;
    int maxMin = 60;
    
    int maxDay = 30;
    int maxMonths = 12;

    float timer = 0;
    

    public enum TimeFormat
    {
        Hour_24,
        Hour_12,
    }
    public enum DateFormat
    {
        MM_DD_YYYY,
        DD_MM_YYYY,
        YYYY_MM_DD,
        YYYY_DD_MM

    }

    private void Awake()
    {
        //hr = EnviroSky.instance.GameTime.Hours;
        //min = EnviroSky.instance.GameTime.Minutes;

        //day = EnviroSky.instance.GameTime.Days/30*month;
        //month = EnviroSky.instance.GameTime.Days / 30;
        //year = EnviroSky.instance.GameTime.Years;

        //if(hr <= 12)
        //{
        //    isAm = true;
        //}

        //SetTimeDateString();
    }

    void Start()
    {
        saveSystem = new EasyFileSave("save_time");
    }


    // Update is called once per frame
    void Update()
    {

        hr = EnviroSky.instance.GameTime.Hours;
        min = EnviroSky.instance.GameTime.Minutes;

        day = 1+EnviroSky.instance.GameTime.Days - (30 * (month-1));
        month = (int)Mathf.Ceil(1+EnviroSky.instance.GameTime.Days / 30);
        year = EnviroSky.instance.GameTime.Years;
        Debug.Log(month);

        //if(timer >= secPerMin)
        //{
        //    min++;
        //    if(min >= maxMin)
        //    {
        //        min = 0;
        //        hr++;
        //        if (hr >= maxHr)
        //        {
        //            hr = 0;
        //            day++;
        //            if (day >= maxDay)
        //            {
        //                day = 1;
        //                month++;
        //                if (month >= maxMonths)
        //                {
        //                    month = 1;
        //                    year++;
        //                }
        //            }
        //        }
        //    }

            SetTimeDateString();

        //    timer = 0;
        //}
        //else 
        //{
        //    timer += Time.deltaTime;
        //}
    }

    void SetTimeDateString()
    {       

        switch (timeFormat)
        {
            case TimeFormat.Hour_12:
            {
                    int h;

                    if (hr >= 13)
                    {
                        
                        h = hr - 12 ;
                    }
                    else if (hr == 0)
                    {
                        
                        h = 12;
                    }
                    else
                    {
                        
                        h = hr;
                    }
                    _time = h + ":";

                    if (min <= 9)
                    {
                        _time += "0" + min;
                    }
                    else
                    {
                        _time += min;
                    }
                    
                    if(isAm == true)
                    {
                        _time += " AM";
                    }
                    else
                    {
                        _time += " PM";
                    }
                    break;
            }
            case TimeFormat.Hour_24:
                {
                    if(hr <= 9)
                    {
                        _time = "0" + hr + ":";
                    }
                    else
                    {
                        _time = hr + ":";
                    }

                    if (min <= 9)
                    {
                        _time += "0" + min;
                    }
                    else
                    {
                        _time += min;
                    }
                    break;
                }

        }
        switch (dateFormat)
        {
            case DateFormat.DD_MM_YYYY:
                {
                    _date = day +"." + month + "." + year;

                    break;
                }
            case DateFormat.MM_DD_YYYY:
                {
                    _date = month + "/" + day + "/" + year;
                    break;
                }
            case DateFormat.YYYY_DD_MM:
                {
                    _date = year + "/" + day + "/" + month;
                    break;
                }
            case DateFormat.YYYY_MM_DD:
                {
                    _date = year + "/" + month + "/" + day;
                    break;
                }
        }
        
        for (int i = 0; i < UI_TIME_TEXT.Length; i++)
        {
            UI_TIME_TEXT[i].text = _time;
        }
        for (int i = 0; i < UI_DATE_TEXT.Length; i++)
        {
            UI_DATE_TEXT[i].text = _date;
        }

    }

}
