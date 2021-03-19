using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DevelopmentUISliderTexts : MonoBehaviour
{
    public Slider graphicsSlider;
    public Slider soundSlider;
    public Slider gameplaySlider;
    public Slider contentSlider;
    public Slider controlSlider;

    public TMP_Text graphicsValue;
    public TMP_Text soundValue;
    public TMP_Text gameplayValue;
    public TMP_Text contentValue;
    public TMP_Text controlValue;
    public 
    // Start is called before the first frame update
    void Start()
    {
        UpdateTextValues();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTextValues()
    {
        graphicsValue.text = graphicsSlider.value + "/10";
        soundValue.text = soundSlider.value + "/10";
        gameplayValue.text = gameplaySlider.value + "/10";
        contentValue.text = contentSlider.value + "/10";
        controlValue.text = controlSlider.value + "/10";

    }
}
