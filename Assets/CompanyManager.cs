using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompanyManager : MonoBehaviour
{
    private static CompanyManager instance;

    public string playerName;
    public string companyName;
    public int country;
    public int difficulty;
    public int startingMoney;

    public static CompanyManager Instance { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePlayerName()
    {
        playerName = GameObject.Find("PlayernameInput").GetComponent<TMP_InputField>().text;
    }
    public void ChangeCompanyName()
    {
        companyName = GameObject.Find("Companynameinput").GetComponent<TMP_InputField>().text;
    }

    public void ChangeCountry()
    {
        country = GameObject.Find("CountrySelection").GetComponent<TMP_Dropdown>().value;
    }
    public void ChangeDifficulty()
    {
        difficulty = GameObject.Find("DifficultySelection").GetComponent<TMP_Dropdown>().value;
    }

    public void SetStartingParameters()
    {
        //Difficulty-Dependencies
        if(difficulty == 0)
        {
            startingMoney = 20000;
        }
        if (difficulty == 1)
        {
            startingMoney = 30000;
        }
        if (difficulty == 2)
        {
            startingMoney = 10000;
        }
        
        //Country-Dependencies

        //Other
    }

}
