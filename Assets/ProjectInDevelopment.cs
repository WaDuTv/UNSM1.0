using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectInDevelopment : MonoBehaviour
{
    public string projectName;
    public string mainGenre;
    public string subGenre;
    public string Theme;

    public string system;

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
    public int startMonth;
    public int startYear;

    public int endDay;
    public int endMonth;
    public int endYear;

    public int sendAwayDay;
    public int sendAwayMonth;
    public int sendAwayYear;
    public int reviewDay;
    public int reviewMonth;
    public int reviewYear;

    public bool isFinished = false;
    public bool isRated = false;
    public bool hasBeenSent = false;
    
    public List<string> assignedStaff;

    public string publisher;
    public int numberOfCopiesAvailable;
    public bool isOnMarket;

    public int customersKids;
    public int customersTeens;
    public int customersAdults;
    public int customersSeniors;
    public int customersEveryone;
    public bool initialCustomersSet;

    public int pastMonthsCustomersKids;
    public int pastMonthsCustomersTeens;
    public int pastMonthsCustomersAdults;
    public int pastMonthsCustomersSeniors;
    public int pastMonthsCustomersEveryone;

    public float initalInterest;
    public float interestDecline;
    public float currentInterest;
    public int monthsOnMarket;

    public Transform finishedGameContainer;
    [SerializeField]
    private int developmentInYears;
    [SerializeField]
    private Clock clock;

    // Start is called before the first frame update
    void Start()
    {
        finishedGameContainer = GameObject.Find("MyFinishedGames").transform;
        clock = GameObject.Find("TimeManager").GetComponent<Clock>();
        StartDevelopmentCycle();
        
        if (gameSize == "C")
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
        if(clock.day >= endDay && clock.month >= endMonth && clock.year >= endYear && isFinished == false && isRated == false)
        {
            isFinished = true;            
            this.transform.parent = finishedGameContainer;
            GetComponent<CalculateGameScore>().GameScore();            
        }
        if (clock.day >= reviewDay && clock.month >= reviewMonth  && clock.year >= reviewYear && isFinished ==true  && hasBeenSent == true)
        {
            isRated = true;            
        }

    }

    public void StartDevelopmentCycle()
    {       
        startDay = clock.day;
        startMonth = clock.month;
        startYear = clock.year;

        developmentInYears = ((int)setDevelopmentTime + startDay + (startMonth-1)*30) / 360;

        if (developmentInYears <= 1)
        {
            endDay = startDay;
            endMonth = startMonth + (int)setDevelopmentTime / 30;
        }
        if (developmentInYears >= 1)
        {
            endDay = startDay;
            endMonth = ((int)setDevelopmentTime / 30 + startMonth) - 12;
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

    public void sendToRating()
    {
        sendAwayDay = clock.day;
        sendAwayMonth = clock.month;
        sendAwayYear = clock.year;

        reviewDay = sendAwayDay + Random.Range(5, 11);

        if(reviewDay <= 30)
        {            
            reviewMonth = sendAwayMonth; 
        }
        if(reviewDay > 30)
        {
            reviewDay = reviewDay - 30;
            reviewMonth = sendAwayMonth + 1;         
        }

        if(reviewMonth <= 12 )
        {
            reviewYear = sendAwayYear;
        }
        if(reviewMonth > 12)
        {
            reviewMonth = reviewMonth - 12;
            reviewYear = sendAwayYear + 1;
        }
        hasBeenSent = true;
    }
}
