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

    public TMP_InputField getPlayername;
    public TMP_InputField getCompanyname;
    public TMP_Dropdown getDifficulty;
    public TMP_Dropdown getCountry;

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

    private void Start()
    {
        country = 0;
        difficulty = 0;
        startingMoney = 20000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePlayerName()
    {
        playerName = getPlayername.text;
    }
    public void ChangeCompanyName()
    {
        companyName = getCompanyname.text;
    }

    public void ChangeCountry()
    {
        country = getCountry.value;
    }
    public void ChangeDifficulty()
    {
        difficulty = getDifficulty.value;
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
