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

    public List<GameObject> gameTypes = null;
    public List<GameObject> gameThemes = null;
    public GameObject gameGenres;
    public GameObject gameThemeParent;
    private List<string> genreOptions = new List<string>(); 
    private List<string> subGenreOptions = new List<string>();
    private List<string> themeOptions = new List<string>();

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
        subGenreDropdown.RefreshShownValue();
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
        mainGenreDropdown.RefreshShownValue();
    }

}
