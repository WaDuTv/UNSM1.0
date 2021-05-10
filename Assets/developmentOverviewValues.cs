using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class developmentOverviewValues : MonoBehaviour
{
    public GameDevelopmentProgressbarCalculation gameInProgressStats;
    public ReviewOverviewDisplay reviewStats;

    public string projectLead;
    public string graphicsLead;
    public string soundLead;
    public string leadingProgrammer;
    public string designLead;

    public int reviewReadyDay;
    public int reviewReadyYear;

    public string reviewGraphicsLead;
    public string reviewContentLead;

    public int endDay;
    public int endMonth;
    public int endYear;

    public string systemName;

    [SerializeField]
    private AlwaysVisibleHolderScript holder;
    [SerializeField]
    private GameObject developmentOverviewView;
    [SerializeField]
    private Transform finishedGamesContainer;
    [SerializeField]
    private GameObject thisProject;
    [SerializeField]
    private Transform staffContainer;
    [SerializeField]
    private List<string> staffList;
    [SerializeField]
    private GameObject reviewSplashScreen;
    [SerializeField]
    private sellGameButtonScript sellGameButtonScript;

    private GameObject player;

    private List<int> programmingStats;
    private List<int> soundStats;
    private List<int> graphicStats;
    private List<int> designStats;
    private List<int> totalStats;

    private List<int> totalGraphics;
    private List<int> totalContent;

    private List<string> firstNames;
    private List<string> lastNames;
    // Start is called before the first frame update
    void Start()
    {
        //finishedGamesContainer = GameObject.Find("CurrentActiveProjects").transform; /*<< Just for Testing, else use line below*/        
        staffContainer = GameObject.Find("CompanyStaff").transform;        
        gameInProgressStats = this.gameObject.GetComponent<GameDevelopmentProgressbarCalculation>();        
        holder = GameObject.Find("AlwaysVisibleHolder").GetComponent<AlwaysVisibleHolderScript>();
        developmentOverviewView = holder.developmentOverviewBodyView;
        reviewSplashScreen = holder.reviewSplashScreen;
        player = holder.playerPrefab;

        programmingStats = new List<int>();
        soundStats = new List<int>();
        graphicStats = new List<int>();
        designStats = new List<int>();
        totalStats = new List<int>();

        firstNames = new List<string>();
        lastNames = new List<string>();

        totalGraphics = new List<int>();
        totalContent = new List<int>();       

        //GetAndSetValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetAndSetValues()
    {
        finishedGamesContainer = GameObject.Find("MyFinishedGames").transform;
        thisProject = finishedGamesContainer.Find(gameInProgressStats.projectName).gameObject;
        staffList = thisProject.GetComponent<ProjectInDevelopment>().assignedStaff;
        reviewReadyDay = thisProject.GetComponent<ProjectInDevelopment>().reviewDay;
        reviewReadyYear = thisProject.GetComponent<ProjectInDevelopment>().reviewYear;
        endDay = thisProject.GetComponent<ProjectInDevelopment>().endDay;
        endMonth = thisProject.GetComponent<ProjectInDevelopment>().endMonth;
        endYear = thisProject.GetComponent<ProjectInDevelopment>().endYear;
        systemName = thisProject.GetComponent<ProjectInDevelopment>().system;


        // Set Header Text
        developmentOverviewView.transform.Find("Header").Find("HeaderText").GetComponent<TMP_Text>().text = "Development-Report for: ''" + gameInProgressStats.projectName + "''";

        //Set General Infos
        Transform _generalStats = developmentOverviewView.transform.Find("Body").Find("Left").Find("GeneralStats").transform;

        _generalStats.Find("Genre").GetComponent<TMP_Text>().text = thisProject.GetComponent<ProjectInDevelopment>().mainGenre + " / " + thisProject.GetComponent<ProjectInDevelopment>().subGenre;
        _generalStats.Find("Theme").GetComponent<TMP_Text>().text = thisProject.GetComponent<ProjectInDevelopment>().Theme;
        _generalStats.Find("GameSize").GetComponent<TMP_Text>().text = thisProject.GetComponent<ProjectInDevelopment>().gameSize;
        _generalStats.Find("Target Audience").GetComponent<TMP_Text>().text = thisProject.GetComponent<ProjectInDevelopment>().targetAudience;

        //Set Leading Staff
        Transform _LeadingStaff = developmentOverviewView.transform.Find("Body").Find("Left").Find("StaffLists").transform;
        foreach (string worker in staffList)
        {
            if(worker == player.name.ToString())
            { 
            int _statProgramming = player.GetComponent<StaffHandler>().workerStatProgramming;
            int _statSound = player.GetComponent<StaffHandler>().workerStatSound;
            int _statGraphics = player.GetComponent<StaffHandler>().workerStatGraphics;
            int _statDesign = player.GetComponent<StaffHandler>().workerStatDesign;
            int _totalGraphicsDesign = player.GetComponent<StaffHandler>().workerStatGraphicsAndDesign;
            int _totalContent = player.GetComponent<StaffHandler>().workerStatProgrammingAndDesign;

            int _totalValue = _statProgramming + _statSound + _statGraphics + _statDesign;

            string _workerFirstName = player.GetComponent<StaffHandler>().firstName;
            string _workerLastName = player.GetComponent<StaffHandler>().lastName;


            programmingStats.Add(_statProgramming);
            soundStats.Add(_statSound);
            graphicStats.Add(_statGraphics);
            designStats.Add(_statDesign);
            totalStats.Add(_totalValue);
            totalGraphics.Add(_totalGraphicsDesign);
            totalContent.Add(_totalContent);

            firstNames.Add(_workerFirstName);
            lastNames.Add(_workerLastName);
            }
            if(worker != player.name.ToString())
            {
                int _statProgramming = staffContainer.Find(worker).GetComponent<StaffHandler>().workerStatProgramming;
                int _statSound = staffContainer.Find(worker).GetComponent<StaffHandler>().workerStatSound;
                int _statGraphics = staffContainer.Find(worker).GetComponent<StaffHandler>().workerStatGraphics;
                int _statDesign = staffContainer.Find(worker).GetComponent<StaffHandler>().workerStatDesign;
                int _totalGraphicsDesign = staffContainer.Find(worker).GetComponent<StaffHandler>().workerStatGraphicsAndDesign;
                int _totalContent = staffContainer.Find(worker).GetComponent<StaffHandler>().workerStatProgrammingAndDesign;

                int _totalValue = _statProgramming + _statSound + _statGraphics + _statDesign;

                string _workerFirstName = staffContainer.Find(worker).GetComponent<StaffHandler>().firstName;
                string _workerLastName = staffContainer.Find(worker).GetComponent<StaffHandler>().lastName;


                programmingStats.Add(_statProgramming);
                soundStats.Add(_statSound);
                graphicStats.Add(_statGraphics);
                designStats.Add(_statDesign);
                totalStats.Add(_totalValue);
                totalGraphics.Add(_totalGraphicsDesign);
                totalContent.Add(_totalContent);

                firstNames.Add(_workerFirstName);
                lastNames.Add(_workerLastName);
            }

        }

        int maxProgramming = Mathf.Max(programmingStats.ToArray());
        int[] programmingStatsArray = programmingStats.ToArray();
        int i = 0;

        for (i = 0; i < programmingStatsArray.Length; i++)
        {
            if (programmingStatsArray[i] == maxProgramming)
            {
                leadingProgrammer = firstNames[i] + " " + lastNames[i];
            }
        }

        int maxTotalValue = Mathf.Max(totalStats.ToArray());
        int[] totalValueStatsArray = totalStats.ToArray();

        for (i = 0; i < totalValueStatsArray.Length; i++)
        {
            if (totalValueStatsArray[i] == maxTotalValue)
            {
                projectLead = firstNames[i] + " " + lastNames[i];
            }
        }
        int maxGraphics = Mathf.Max(graphicStats.ToArray());
        int[] graphicsStatsArray = graphicStats.ToArray();

        for (i = 0; i < graphicsStatsArray.Length; i++)
        {
            if (graphicsStatsArray[i] == maxGraphics)
            {
                graphicsLead = firstNames[i] + " " + lastNames[i];
            }
        }
        int maxSound = Mathf.Max(soundStats.ToArray());
        int[] SoundStatsArray = soundStats.ToArray();

        for (i = 0; i < SoundStatsArray.Length; i++)
        {
            if (SoundStatsArray[i] == maxSound)
            {
                soundLead = firstNames[i] + " " + lastNames[i];
            }
        }
        int maxDesign = Mathf.Max(designStats.ToArray());
        int[] DesignStatsArray = designStats.ToArray();

        for (i = 0; i < DesignStatsArray.Length; i++)
        {
            if (DesignStatsArray[i] == maxDesign)
            {
                designLead = firstNames[i] + " " + lastNames[i];
            }
        }
        int maxGraphicsReview = Mathf.Max(totalGraphics.ToArray());
        int[] ReviewGraphicsStatsArray = designStats.ToArray();

        for (i = 0; i < ReviewGraphicsStatsArray.Length; i++)
        {
            if (ReviewGraphicsStatsArray[i] == maxGraphicsReview)
            {
                reviewGraphicsLead = firstNames[i] + " " + lastNames[i];
            }
        }

        int maxContent = Mathf.Max(totalContent.ToArray());
        int[] ContentStatsArray = designStats.ToArray();

        for (i = 0; i < ContentStatsArray.Length; i++)
        {
            if (ContentStatsArray[i] == maxContent)
            {
                reviewContentLead = firstNames[i] + " " + lastNames[i];
            }
        }

        _LeadingStaff.Find("LeadingProgrammer").GetComponent<TMP_Text>().text = leadingProgrammer;        

        _LeadingStaff.Find("ProjectLeader").GetComponent<TMP_Text>().text = projectLead;       

        _LeadingStaff.Find("GraphicsLeader").GetComponent<TMP_Text>().text = graphicsLead;        

        _LeadingStaff.Find("SoundDesignLeader").GetComponent<TMP_Text>().text = soundLead;
        
        _LeadingStaff.Find("GameDesignLeader").GetComponent<TMP_Text>().text = designLead;

        //Set Development Summary (Wanted Values VS. SetValues)
        Transform _barContainers = developmentOverviewView.transform.Find("Body").Find("Right").Find("DevelopmentSummary").Find("BarContainers").transform;

        float _graphicsProgress = (finishedGamesContainer.Find(gameInProgressStats.projectName).GetComponent<CalculateGameScore>().setGraphics / finishedGamesContainer.Find(gameInProgressStats.projectName).GetComponent<CalculateGameScore>().maxGraphics) * 100;
        float _soundProgress = (finishedGamesContainer.Find(gameInProgressStats.projectName).GetComponent<CalculateGameScore>().setSound / finishedGamesContainer.Find(gameInProgressStats.projectName).GetComponent<CalculateGameScore>().maxSound) * 100;
        float _gameplayProgress = (finishedGamesContainer.Find(gameInProgressStats.projectName).GetComponent<CalculateGameScore>().setGameplay / finishedGamesContainer.Find(gameInProgressStats.projectName).GetComponent<CalculateGameScore>().maxGraphics) * 100;
        float _contentProgress = (finishedGamesContainer.Find(gameInProgressStats.projectName).GetComponent<CalculateGameScore>().setGraphics / finishedGamesContainer.Find(gameInProgressStats.projectName).GetComponent<CalculateGameScore>().maxGraphics) * 100;
        float _controlsProgress = (finishedGamesContainer.Find(gameInProgressStats.projectName).GetComponent<CalculateGameScore>().setGraphics / finishedGamesContainer.Find(gameInProgressStats.projectName).GetComponent<CalculateGameScore>().maxGraphics) * 100;

        _barContainers.Find("GraphicsBarContainer").Find("Graphics Progress Bar").GetComponent<Slider>().value = _graphicsProgress;
        _barContainers.Find("SoundBarContainer").Find("Sound Progress Bar").GetComponent<Slider>().value = _soundProgress;
        _barContainers.Find("GameplayBarContainer").Find("Gameplay Progress Bar").GetComponent<Slider>().value = _gameplayProgress;
        _barContainers.Find("ContentBarContainer").Find("Content Progress Bar").GetComponent<Slider>().value = _contentProgress;
        _barContainers.Find("ControlsBarContainer").Find("Controls Progress Bar").GetComponent<Slider>().value = _controlsProgress;

        if(_graphicsProgress > 100)
        {
            _barContainers.Find("GraphicsBarContainer").Find("Graphics%").GetComponent<TMP_Text>().text = "100%";            
        }
        if(_graphicsProgress<=100)
        {
            _barContainers.Find("GraphicsBarContainer").Find("Graphics%").GetComponent<TMP_Text>().text = Mathf.Round(_graphicsProgress).ToString() + "%";
        }
        if(_soundProgress >100)
        {
            _barContainers.Find("SoundBarContainer").Find("Sound%").GetComponent<TMP_Text>().text = "100%";
        }
        if (_soundProgress <= 100)
        {
            _barContainers.Find("SoundBarContainer").Find("Sound%").GetComponent<TMP_Text>().text = Mathf.Round(_soundProgress).ToString() + "%";
        }
        if(_gameplayProgress>100)
        {
            _barContainers.Find("GameplayBarContainer").Find("Gameplay%").GetComponent<TMP_Text>().text = "100%";
        }
        if(_gameplayProgress <= 100)
        {
            _barContainers.Find("GameplayBarContainer").Find("Gameplay%").GetComponent<TMP_Text>().text = Mathf.Round(_gameplayProgress).ToString() + "%";
        }
        if(_contentProgress >100)
        {
            _barContainers.Find("ContentBarContainer").Find("Content%").GetComponent<TMP_Text>().text = "100%";
        }
        if(_contentProgress <= 100)
        {
            _barContainers.Find("ContentBarContainer").Find("Content%").GetComponent<TMP_Text>().text = Mathf.Round(_contentProgress).ToString() + "%";
        }
        if(_controlsProgress > 100)
        {
            _barContainers.Find("ControlsBarContainer").Find("Controls%").GetComponent<TMP_Text>().text = "100%";
        }
        if(_controlsProgress <= 100)
        {
            _barContainers.Find("ControlsBarContainer").Find("Controls%").GetComponent<TMP_Text>().text = Mathf.Round(_controlsProgress).ToString() + "%";
        }

        thisProject.GetComponent<ProjectInDevelopment>().valuesHaveBeenCalculated = true;
    }

    public void GetAndSetReviewValues()
    {
        Transform _reviewScreen = reviewSplashScreen.transform;
        Transform _ratingsBox = _reviewScreen.Find("Right").Find("RatingsBox");

        reviewStats = this.gameObject.GetComponent<ReviewOverviewDisplay>();
        finishedGamesContainer = GameObject.Find("MyFinishedGames").transform;
        thisProject = finishedGamesContainer.Find(reviewStats.projectName).gameObject;
        staffList = thisProject.GetComponent<ProjectInDevelopment>().assignedStaff;
        endDay = thisProject.GetComponent<ProjectInDevelopment>().endDay;
        endMonth = thisProject.GetComponent<ProjectInDevelopment>().endMonth;
        endYear = thisProject.GetComponent<ProjectInDevelopment>().endYear;

        //Set Header Text
        _reviewScreen.Find("Image").Find("HeaderText").GetComponent<TMP_Text>().text = "Reviewresults for " + thisProject.name;

        //Send Project name to Sell Game Button Script
        sellGameButtonScript = GameObject.Find("Button - sellGameButton").GetComponent<sellGameButtonScript>();
        sellGameButtonScript.project = thisProject;

        //Set Overall-Rating Radial Display               
        float _overallRating = thisProject.GetComponent<CalculateGameScore>().finalScore;
        double _overallRatingRounded = Math.Round(_overallRating * 100, 0);

        if (_overallRatingRounded <= 100)
        { 
            _reviewScreen.Find("Center").Find("OverallRating").Find("PercentageText").GetComponent<Text>().text = _overallRatingRounded.ToString() + "%";
        }
        if (_overallRatingRounded > 100)
        {
            _reviewScreen.Find("Center").Find("OverallRating").Find("PercentageText").GetComponent<Text>().text = "100%";
        }
        _reviewScreen.Find("Center").Find("OverallRating").Find("FillingObject").GetComponent<Image>().fillAmount = _overallRating;

        //Set sub-ratings Box Values and Workers
        float _graphicsRating = thisProject.GetComponent<CalculateGameScore>().graphicsScore / thisProject.GetComponent<CalculateGameScore>().maxGraphics;
        float _graphicsRatingRounded = Mathf.Round(_graphicsRating * 100f);
        float _soundRating = thisProject.GetComponent<CalculateGameScore>().soundScore / thisProject.GetComponent<CalculateGameScore>().maxSound;
        float _soundRatingRounded = Mathf.Round(_soundRating * 100f);
        float _gameplayRating = thisProject.GetComponent<CalculateGameScore>().gameplayScore / thisProject.GetComponent<CalculateGameScore>().maxGameplay;
        float _gameplayRatingRounded = Mathf.Round(_gameplayRating * 100f);
        float _contentRating = thisProject.GetComponent<CalculateGameScore>().contentScore / thisProject.GetComponent<CalculateGameScore>().maxContent;
        float _contentRatingRounded = Mathf.Round(_contentRating * 100f);
        float _controlsRating = thisProject.GetComponent<CalculateGameScore>().controlsScore / thisProject.GetComponent<CalculateGameScore>().maxControls;
        float _controlsRatingRounded = Mathf.Round(_controlsRating * 100f);

        
        if(_graphicsRatingRounded > 100)
        {
            _ratingsBox.Find("GraphicsRating").Find("GraphicsText").Find("Progress Bar").Find("%").GetComponent<TMP_Text>().text =  "100%";
        }
        if (_graphicsRatingRounded <= 100)
        {
            _ratingsBox.Find("GraphicsRating").Find("GraphicsText").Find("Progress Bar").Find("%").GetComponent<TMP_Text>().text = _graphicsRatingRounded + "%";
        }
        if(_soundRatingRounded >100)
        {
            _ratingsBox.Find("SoundRating").Find("SoundText").Find("Progress Bar").Find("%").GetComponent<TMP_Text>().text = "100%";
        }
        if(_soundRatingRounded <=100) 
        {
            _ratingsBox.Find("SoundRating").Find("SoundText").Find("Progress Bar").Find("%").GetComponent<TMP_Text>().text = _soundRatingRounded + "%";
        }
        if(_gameplayRatingRounded >100)
        {
            _ratingsBox.Find("GameplayRating").Find("GameplayText").Find("Progress Bar").Find("%").GetComponent<TMP_Text>().text = "100%";
        }
        if(_gameplayRatingRounded <=100)
        {
            _ratingsBox.Find("GameplayRating").Find("GameplayText").Find("Progress Bar").Find("%").GetComponent<TMP_Text>().text = _gameplayRatingRounded + "%";
        }
        if(_contentRatingRounded > 100)
        {
            _ratingsBox.Find("ContentRating").Find("ContentText").Find("Progress Bar").Find("%").GetComponent<TMP_Text>().text = "100%";
        }
        if(_contentRatingRounded <= 100)
        {
            _ratingsBox.Find("ContentRating").Find("ContentText").Find("Progress Bar").Find("%").GetComponent<TMP_Text>().text = _contentRatingRounded + "%";
        }
        if(_controlsRatingRounded >100)
        {
            _ratingsBox.Find("ControlsRating").Find("ControlsText").Find("Progress Bar").Find("%").GetComponent<TMP_Text>().text = "100%";
        }
        if(_controlsRatingRounded <= 100)
        {
            _ratingsBox.Find("ControlsRating").Find("ControlsText").Find("Progress Bar").Find("%").GetComponent<TMP_Text>().text = _controlsRatingRounded + "%";
        }
        
        _ratingsBox.Find("GraphicsRating").Find("GraphicsText").Find("Progress Bar").GetComponent<Slider>().value = _graphicsRating;
        _ratingsBox.Find("SoundRating").Find("SoundText").Find("Progress Bar").GetComponent<Slider>().value = _soundRating;
        _ratingsBox.Find("GameplayRating").Find("GameplayText").Find("Progress Bar").GetComponent<Slider>().value = _gameplayRating;
        _ratingsBox.Find("ContentRating").Find("ContentText").Find("Progress Bar").GetComponent<Slider>().value = _contentRating;
        _ratingsBox.Find("ControlsRating").Find("ControlsText").Find("Progress Bar").GetComponent<Slider>().value = _controlsRating;

        //Calculate responsible Developers
        Transform _LeadingStaff = developmentOverviewView.transform.Find("Body").Find("Left").Find("StaffLists").transform;

        foreach (string worker in staffList)
        {
            if (worker == player.name.ToString())
            {
                int _statProgramming = player.GetComponent<StaffHandler>().workerStatProgramming;
                int _statSound = player.GetComponent<StaffHandler>().workerStatSound;
                int _statGraphics = player.GetComponent<StaffHandler>().workerStatGraphics;
                int _statDesign = player.GetComponent<StaffHandler>().workerStatDesign;
                int _totalGraphicsDesign = player.GetComponent<StaffHandler>().workerStatGraphicsAndDesign;
                int _totalContent = player.GetComponent<StaffHandler>().workerStatProgrammingAndDesign;

                int _totalValue = _statProgramming + _statSound + _statGraphics + _statDesign;

                string _workerFirstName = player.GetComponent<StaffHandler>().firstName;
                string _workerLastName = player.GetComponent<StaffHandler>().lastName;


                programmingStats.Add(_statProgramming);
                soundStats.Add(_statSound);
                graphicStats.Add(_statGraphics);
                designStats.Add(_statDesign);
                totalStats.Add(_totalValue);
                totalGraphics.Add(_totalGraphicsDesign);
                totalContent.Add(_totalContent);

                firstNames.Add(_workerFirstName);
                lastNames.Add(_workerLastName);
            }
            if (worker != player.name.ToString())
            {
                int _statProgramming = staffContainer.Find(worker).GetComponent<StaffHandler>().workerStatProgramming;
                int _statSound = staffContainer.Find(worker).GetComponent<StaffHandler>().workerStatSound;
                int _statGraphics = staffContainer.Find(worker).GetComponent<StaffHandler>().workerStatGraphics;
                int _statDesign = staffContainer.Find(worker).GetComponent<StaffHandler>().workerStatDesign;
                int _totalGraphicsDesign = staffContainer.Find(worker).GetComponent<StaffHandler>().workerStatGraphicsAndDesign;
                int _totalContent = staffContainer.Find(worker).GetComponent<StaffHandler>().workerStatProgrammingAndDesign;

                int _totalValue = _statProgramming + _statSound + _statGraphics + _statDesign;

                string _workerFirstName = staffContainer.Find(worker).GetComponent<StaffHandler>().firstName;
                string _workerLastName = staffContainer.Find(worker).GetComponent<StaffHandler>().lastName;


                programmingStats.Add(_statProgramming);
                soundStats.Add(_statSound);
                graphicStats.Add(_statGraphics);
                designStats.Add(_statDesign);
                totalStats.Add(_totalValue);
                totalGraphics.Add(_totalGraphicsDesign);
                totalContent.Add(_totalContent);

                firstNames.Add(_workerFirstName);
                lastNames.Add(_workerLastName);
            }


        }

        int maxProgramming = Mathf.Max(programmingStats.ToArray());
        int[] programmingStatsArray = programmingStats.ToArray();
        int i = 0;

        for (i = 0; i < programmingStatsArray.Length; i++)
        {
            if (programmingStatsArray[i] == maxProgramming)
            {
                leadingProgrammer = firstNames[i] + " " + lastNames[i];
            }
        }

        int maxTotalValue = Mathf.Max(totalStats.ToArray());
        int[] totalValueStatsArray = totalStats.ToArray();

        for (i = 0; i < totalValueStatsArray.Length; i++)
        {
            if (totalValueStatsArray[i] == maxTotalValue)
            {
                projectLead = firstNames[i] + " " + lastNames[i];
            }
        }
        int maxGraphics = Mathf.Max(graphicStats.ToArray());
        int[] graphicsStatsArray = graphicStats.ToArray();

        for (i = 0; i < graphicsStatsArray.Length; i++)
        {
            if (graphicsStatsArray[i] == maxGraphics)
            {
                graphicsLead = firstNames[i] + " " + lastNames[i];
            }
        }
        int maxSound = Mathf.Max(soundStats.ToArray());
        int[] SoundStatsArray = soundStats.ToArray();

        for (i = 0; i < SoundStatsArray.Length; i++)
        {
            if (SoundStatsArray[i] == maxSound)
            {
                soundLead = firstNames[i] + " " + lastNames[i];
            }
        }
        int maxDesign = Mathf.Max(designStats.ToArray());
        int[] DesignStatsArray = designStats.ToArray();

        for (i = 0; i < DesignStatsArray.Length; i++)
        {
            if (DesignStatsArray[i] == maxDesign)
            {
                designLead = firstNames[i] + " " + lastNames[i];
            }
        }
        int maxGraphicsReview = Mathf.Max(totalGraphics.ToArray());
        int[] ReviewGraphicsStatsArray = totalGraphics.ToArray();

        for (i = 0; i < ReviewGraphicsStatsArray.Length; i++)
        {
            if (ReviewGraphicsStatsArray[i] == maxGraphicsReview)
            {
                reviewGraphicsLead = firstNames[i] + " " + lastNames[i];
                Debug.Log(reviewGraphicsLead);
            }
        }

        int maxContent = Mathf.Max(totalContent.ToArray());
        int[] ContentStatsArray = totalContent.ToArray();

        for (i = 0; i < ContentStatsArray.Length; i++)
        {
            if (ContentStatsArray[i] == maxContent)
            {
                reviewContentLead = firstNames[i] + " " + lastNames[i];
                Debug.Log(reviewContentLead);
            }
        }

        _ratingsBox.Find("GraphicsRating").Find("LeadingDesigner").GetComponent<TMP_Text>().text = reviewGraphicsLead;
        _ratingsBox.Find("SoundRating").Find("LeadingDesigner").GetComponent<TMP_Text>().text = soundLead;
        _ratingsBox.Find("GameplayRating").Find("LeadingDesigner").GetComponent<TMP_Text>().text = leadingProgrammer;               
        _ratingsBox.Find("ContentRating").Find("LeadingDesigner").GetComponent<TMP_Text>().text = reviewContentLead;
        _ratingsBox.Find("ControlsRating").Find("LeadingDesigner").GetComponent<TMP_Text>().text = leadingProgrammer;


    }

        public void DetstroyDevelopmentProgressBar()
    {        
        Destroy(this.gameObject);
    }
}


