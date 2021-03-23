using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class setText : MonoBehaviour
{
    public TMP_Text companyName;
    public TMP_Text playerWelcome;
    public CompanyManager companyManager;
    
    // Start is called before the first frame update
    void Start()
    {
        companyManager = FindObjectOfType<CompanyManager>();
        if (companyManager != null)
        {
            companyName.text = companyManager.companyName;
            playerWelcome.text = "Welcome back, " + companyManager.playerName + "!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
