using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResetUIElements : MonoBehaviour
{
    public TMP_InputField newGameName;
    public NewGameSetup newGameSetupScript;
    public TMP_Dropdown gameSize;
    public TMP_Dropdown TargetAudience;
    public TMP_InputField price;

    public Slider graphicSlider;
    public Slider soundSlider;
    public Slider gameplaySlider;
    public Slider contentSlider;
    public Slider controlsSlider;
    public Slider developmentTimeSlider;

    public GameObject availableStaffList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetNewGameSetupPage()
    {
        newGameName.text = "";
        newGameSetupScript.mainGenreDropdown.value = 0;
        newGameSetupScript.subGenreDropdown.value = 0;
        newGameSetupScript.themeDropdown.value = 0;
        gameSize.value = 0;
        TargetAudience.value = 0;
        price.text = "";

        gameplaySlider.value = 5;
        soundSlider.value = 5;
        gameplaySlider.value = 5;
        contentSlider.value = 5;
        controlsSlider.value = 5;
        developmentTimeSlider.value = 3;

        
    }
}
