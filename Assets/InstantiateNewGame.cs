using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InstantiateNewGame : MonoBehaviour
{
    public GameObject newActiveProjectPrefab;
    public Transform prefabParent;

    public TMP_InputField projectName;
    public TMP_Text mainGenre;
    public TMP_Text subGenre;
    public TMP_Text theme;
    public TMP_Text gameSize;
    public TMP_Text targetAudience;
    public TMP_InputField price;

    public Slider setGraphics;
    public Slider setSound;
    public Slider setGameplay;
    public Slider setContent;
    public Slider setControls;
    public Slider setDevelopmentTime;

    public Transform gameGenreContainer;

    public float OptimumDevelopmentTime;

    

    [SerializeField]
    private ProjectInDevelopment projectSettings;

    public AssignStaffToNewGame getStaffListfromHere;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetUpNewGame()
    {
        GameObject activeProject = Instantiate(newActiveProjectPrefab, prefabParent);
        projectSettings = activeProject.GetComponent<ProjectInDevelopment>();

        projectSettings.projectName = projectName.text;
        activeProject.name = projectName.text;
        projectSettings.mainGenre = mainGenre.text;
        projectSettings.subGenre = subGenre.text;
        projectSettings.Theme = theme.text;
        projectSettings.gameSize = gameSize.text;
        projectSettings.targetAudience = targetAudience.text;
        string priceString = price.text.ToString();
        projectSettings.setPrice = int.Parse(priceString);
        //projectSettings.setPrice = System.Convert.ToInt32(priceString);

        projectSettings.setGraphics = setGraphics.value;
        projectSettings.setSound = setSound.value;
        projectSettings.setGameplay = setGameplay.value;
        projectSettings.setContent = setContent.value;
        projectSettings.setControls = setControls.value;
        projectSettings.setDevelopmentTime = setDevelopmentTime.value*30;

        projectSettings.optimumGraphics = gameGenreContainer.Find(projectSettings.mainGenre).GetComponent<GameGenreHandler>().gameTypeSO.optimumGraphics;
        projectSettings.optimumSound = gameGenreContainer.Find(projectSettings.mainGenre).GetComponent<GameGenreHandler>().gameTypeSO.optimumSound;
        projectSettings.optimumGameplay = gameGenreContainer.Find(projectSettings.mainGenre).GetComponent<GameGenreHandler>().gameTypeSO.optimumGameplay;
        projectSettings.optimumContent = gameGenreContainer.Find(projectSettings.mainGenre).GetComponent<GameGenreHandler>().gameTypeSO.optimumContent;
        projectSettings.optimumControls = gameGenreContainer.Find(projectSettings.mainGenre).GetComponent<GameGenreHandler>().gameTypeSO.optimumControls;

        CalculateOptimumDevelopmentTime();
        projectSettings.optimumDevelopmentTime = OptimumDevelopmentTime;

        projectSettings.assignedStaff = getStaffListfromHere.assignedStaff;
    }

    public void CalculateOptimumDevelopmentTime()
    {
        if (gameSize.text == "C")
        {
            OptimumDevelopmentTime = 6 * 30;
        }
        if (gameSize.text == "C+")
        {
            OptimumDevelopmentTime = 9 * 30;
        }
        if (gameSize.text == "B")
        {
            OptimumDevelopmentTime = 12 * 30;
        }
        if (gameSize.text == "B+")
        {
            OptimumDevelopmentTime = 16 * 30;
        }
        if (gameSize.text == "A")
        {
            OptimumDevelopmentTime = 18 * 30;
        }
        if (gameSize.text == "AA")
        {
            OptimumDevelopmentTime = 24 * 30;
        }
        if (gameSize.text == "AAA")
        {
            OptimumDevelopmentTime = 36 * 30;
        }

    }  

}