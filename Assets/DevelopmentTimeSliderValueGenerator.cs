using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DevelopmentTimeSliderValueGenerator : MonoBehaviour
{
    public Slider slider;
    
    public TMP_Text shownValue;
    public TMP_Text gameSize;
    
    // Start is called before the first frame update
    void Start()
    {
        shownValue.text = slider.value.ToString() + " Months (Max: " + slider.maxValue.ToString() + ")";
        if (gameSize.text == "C")
        {
            slider.maxValue = 9;
        }
        if (gameSize.text == "C+")
        {
            slider.maxValue = 11;
        }
        if (gameSize.text == "B")
        {
            slider.maxValue = 14;
        }
        if (gameSize.text == "B+")
        {
            slider.maxValue = 19;
        }
        if (gameSize.text == "A")
        {
            slider.maxValue = 21;
        }
        if (gameSize.text == "AA")
        {
            slider.maxValue = 30;
        }
        if (gameSize.text == "AAA")
        {
            slider.maxValue = 48;
        }

    }

    private void Update()
    {
        ChangeTextValue();
    }

    public void ChangeTextValue()
    {
        shownValue.text = slider.value.ToString() + " Months (Max: " + slider.maxValue.ToString() + ")";
    }

    public void UpdateMaxSliderValue ()
    {
        if (gameSize.text == "C")
        {
            slider.maxValue = 9;
        }
        if (gameSize.text == "C+")
        {
            slider.maxValue = 11;
        }
        if (gameSize.text == "B")
        {
            slider.maxValue = 14;
        }
        if (gameSize.text == "B+")
        {
            slider.maxValue = 19;
        }
        if (gameSize.text == "A")
        {
            slider.maxValue = 21;
        }
        if (gameSize.text == "AA")
        {
            slider.maxValue = 30;
        }
        if (gameSize.text == "AAA")
        {
            slider.maxValue = 48;
        }
    }
}
