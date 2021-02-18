using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;
using TMPro;
using TigerForge;

public class SettingsMenu : MonoBehaviour
{

    public saveManager sm;

    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    public Dropdown qualityDropdown;

    public TMP_Dropdown languageDropdown;

    Resolution[] resolutions;

    private void Awake()
    {
        
    }

    private void Start()
    {
        sm = GameObject.Find("SaveManager").GetComponent<saveManager>();        

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " X " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        int currentQualityLevel = QualitySettings.GetQualityLevel();
        qualityDropdown.value = currentQualityLevel;
        qualityDropdown.RefreshShownValue();
     
    }

    private void Update()
    {

    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void setLanguage()
    {
        
        //// Wait for the localization system to initialize, loading Locales, preloading, etc.
        //yield return LocalizationSettings.InitializationOperation;

        // This variable selects the language. For example, if in the table your first language is English then 0 = English. If the second language in the table is Russian then 1 = Russian etc.
        int i = languageDropdown.value;

        // This part changes the language     
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[i];

        sm.SaveLanguage();
       
    }

}


