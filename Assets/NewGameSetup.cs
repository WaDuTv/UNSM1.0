using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class NewGameSetup : MonoBehaviour
{

    public TMP_Dropdown mainGenreDropdown;
    public TMP_Dropdown subGenreDropdown;
    public TMP_Dropdown themeDropdown;
    public TMP_Dropdown systemSelectDropdown;

    public List<GameObject> gameTypes = null;
    public List<GameObject> gameThemes = null;
    public List<GameObject> availableSystems = null;
    public GameObject gameGenres;
    public GameObject gameThemeParent;
    public GameObject availableSystemsParent;
    private List<string> genreOptions = new List<string>(); 
    private List<string> subGenreOptions = new List<string>();
    private List<string> themeOptions = new List<string>();
    private List<string> systemOptions = new List<string>();
    

    private void Awake()
    {
        Transform[] genres = gameGenres.GetComponentsInChildren<Transform>();
        foreach (Transform transform in genres)
        {
            if (transform != null && transform.gameObject != null && transform.gameObject != gameGenres)
            {
                gameTypes.Add(transform.gameObject);
            }
        }
        Transform[] themes = gameThemeParent.GetComponentsInChildren<Transform>();
        foreach (Transform transform in themes)
        {
            if (transform != null && transform.gameObject != null && transform.gameObject != gameThemeParent)
            {
                gameThemes.Add(transform.gameObject);
            }
        }
        Transform[] systems = availableSystemsParent.GetComponentsInChildren<Transform>();
        foreach (Transform transform in systems)
        {
            if (transform!=null && transform.gameObject != null && transform.gameObject != availableSystemsParent)
            {
                availableSystems.Add(transform.gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        mainGenreDropdown.ClearOptions();

        
        for (int i = 0; i < gameTypes.Count; i++)
        {
            string genreOption = gameTypes[i].name;
            genreOptions.Add(genreOption);
        }

        mainGenreDropdown.AddOptions(genreOptions);
        mainGenreDropdown.RefreshShownValue();

        subGenreDropdown.ClearOptions();

        
        for (int i = 0; i < gameTypes.Count; i++)
        {
            string subGenreOption = gameTypes[i].name;
            if (subGenreOption != mainGenreDropdown.GetComponentInChildren<TMP_Text>().text)
            {                
                subGenreOptions.Add(subGenreOption);
            }
        }

        subGenreDropdown.AddOptions(subGenreOptions);        
        subGenreDropdown.RefreshShownValue();

        themeDropdown.ClearOptions();


        for (int i = 0; i < gameThemes.Count; i++)
        {
            string themeOption = gameThemes[i].name;
            themeOptions.Add(themeOption);
        }

        themeDropdown.AddOptions(themeOptions);
        themeDropdown.RefreshShownValue();

        systemSelectDropdown.ClearOptions();

        for (int i = 0; i < availableSystems.Count; i++)
        {
            string systemOption = availableSystems[i].GetComponent<gamingSystemInfos>().systemName+" ("+ availableSystems[i].GetComponent<gamingSystemInfos>().marketShare*100+"% marketshare)";
            systemOptions.Add(systemOption);
        }

        systemSelectDropdown.AddOptions(systemOptions);
        systemSelectDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkDoubleSubGenres()
    {
        subGenreOptions.Clear();
        for (int i = 0; i < gameTypes.Count; i++)
        {            
            string subGenreOption = gameTypes[i].name;            
            if (subGenreOption != mainGenreDropdown.GetComponentInChildren<TMP_Text>().text)
            {
                subGenreOptions.Add(subGenreOption);
            }

        }
        subGenreDropdown.ClearOptions();
        subGenreDropdown.AddOptions(subGenreOptions);
        if (mainGenreDropdown.transform.Find("Label").GetComponent<TextMeshProUGUI>().text == subGenreDropdown.transform.Find("Label").GetComponent<TextMeshProUGUI>().text)
        {
            subGenreDropdown.RefreshShownValue();
        }

    }
    public void checkDoubleMainGenres()
    {
        genreOptions.Clear();
        for (int i = 0; i < gameTypes.Count; i++)
        {
            string genreOption = gameTypes[i].name;
            if (genreOption != subGenreDropdown.GetComponentInChildren<TMP_Text>().text)
            {
                genreOptions.Add(genreOption);
            }

        }
        mainGenreDropdown.ClearOptions();
        mainGenreDropdown.AddOptions(subGenreOptions);      
        if(subGenreDropdown.transform.Find("Label").GetComponent<TextMeshProUGUI>().text == mainGenreDropdown.transform.Find("Label").GetComponent<TextMeshProUGUI>().text  )
        {
            mainGenreDropdown.RefreshShownValue();
        }
    }

}
