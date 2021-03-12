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

    public List<GameTypeSO> gameTypes = null;
    private List<string> genreOptions = new List<string>(); 
    private List<string> subGenreOptions = new List<string>();

    private void Awake()
    {
        gameTypes = EconomyManager.instance.gameTypes;
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
        
}
