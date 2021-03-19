using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectInDevelopment : MonoBehaviour
{
    public string projectName;
    public string mainGenre;
    public string subGenre;
    public string Theme;

    public string gameSize;
    public string targetAudience;

    public float setGraphics;
    public float setSound;
    public float setGameplay;
    public float setContent;
    public float setControls;

    public int setPrice;
    public int defaultPrice;

    public float setDevelopmentTime;

    public float optimumGraphics;
    public float optimumSound;
    public float optimumGameplay;
    public float optimumContent;
    public float optimumControls;

    public float optimumDevelopmentTime;

    public int startDay;
    public int startYear;

    public int endDay;
    public int endYear;

    public bool isFinished = false;
    public bool isRated = false;
    
    public List<string> assignedStaff;

    public Transform finishedGameContainer;
    [SerializeField]
    private int developmentInYears;

    // Start is called before the first frame update
    void Start()
    {
        StartDevelopmentCycle();
        finishedGameContainer = GameObject.Find("MyFinishedGames").transform;
        if(gameSize == "C")
        {
            defaultPrice = 10;
        }
        if (gameSize == "C+")
        {
            defaultPrice = 12;
        }
        if (gameSize == "B")
        {
            defaultPrice = 18;
        }
        if (gameSize == "B+")
        {
            defaultPrice = 25;
        }
        if (gameSize == "A")
        {
            defaultPrice = 35;
        }
        if (gameSize == "AA")
        {
            defaultPrice = 45;
        }
        if (gameSize == "AAA")
        {
            defaultPrice = 60;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(EnviroSky.instance.GameTime.Days >= endDay && EnviroSky.instance.GameTime.Years >= endYear && isRated == false)
        {
            isFinished = true;            
            this.transform.parent = finishedGameContainer;
            GetComponent<CalculateGameScore>().GameScore();
            isRated = true;
        }
    }

    public void StartDevelopmentCycle()
    {       
        startDay = EnviroSky.instance.GameTime.Days;
        startYear = EnviroSky.instance.GameTime.Years;

        developmentInYears = ((int)setDevelopmentTime + startDay) / 360;

        if (developmentInYears <= 1)
        {
            endDay = startDay + (int)setDevelopmentTime;
        }
        if (startDay + (int)setDevelopmentTime >= 1)
        {
            endDay = startDay + (int)setDevelopmentTime - 360*developmentInYears;
        }
        if (startDay + (int)setDevelopmentTime <= 1)
        {
            endYear = startYear;
        }
        if (startDay + (int)setDevelopmentTime >= 1)
        {
            endYear = startYear + developmentInYears;
        }
    }
}
