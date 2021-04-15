using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CompanyManager : MonoBehaviour
{
    private static CompanyManager instance;

    public string playerName;
    public string companyName;
    public int country;
    public int difficulty;
    public int startingMoney;

    public int playerStatProgramming;
    public int playerStatSound;
    public int playerStatGraphics;
    public int playerStatDesign;
    

    public static CompanyManager Instance { get; private set; }

    public TMP_InputField getPlayername;
    public TMP_InputField getCompanyname;
    public TMP_Dropdown getDifficulty;
    public TMP_Dropdown getCountry;

    public Slider getPlayStatProgramming;
    public Slider getPlayStatSound;
    public Slider getPlayStatGraphics;
    public Slider getPlayStatDesign;

    public TMP_Text programmingValue;
    public TMP_Text soundValue;
    public TMP_Text graphicsValue;
    public TMP_Text designValue;

    public GameObject playerModel;
    public Material playerMaterial;

    public int playerModelIndex;
    public int playerMaterialIndex;

    public List<GameObject> playerModels;

    public List<Material> playerMaterials;

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
        playerMaterial = playerMaterials[playerMaterialIndex];
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

    public void ChangePlayerStatProgramming()
    {
        playerStatProgramming = (int)getPlayStatProgramming.value;
        programmingValue.text = getPlayStatProgramming.value.ToString() + "/10";
    }
    public void ChangePlayerStatSound()
    {
        playerStatSound = (int)getPlayStatSound.value;
        soundValue.text = getPlayStatSound.value.ToString() + "/10";
    }
    public void ChangePlayerStatGraphics()
    {
        playerStatGraphics = (int)getPlayStatGraphics.value;
        graphicsValue.text = getPlayStatGraphics.value.ToString() + "/10";
    }
    public void ChangePlayerStatDesign()
    {
        playerStatDesign = (int)getPlayStatDesign.value;
        designValue.text = getPlayStatDesign.value.ToString() + "/10";
    }

    public void SetStartingParameters()
    {
        //PlayerStats

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
