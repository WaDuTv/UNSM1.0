using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ShopScript : MonoBehaviour
{
    public int bankamount;
    public Button plantButton;
    public TextMeshProUGUI bankAmountText;
    public BuildScript buildScript;


    // Start is called before the first frame update
    void Start()
    {
        bankamount = bankamount + GameObject.Find("CompanyManager").GetComponent<CompanyManager>().startingMoney;
        bankAmountText.text = bankamount.ToString();
    }

    // Update is called once per frame
    void Update()
    {        
        bankAmountText.text = bankamount.ToString();        
    }

    public void BuyFromShop(int price)
    {           
        if (bankamount >= price)
        {
            Debug.Log("Geld vor Kauf:" + bankamount);                                    
                bankAmountText.text = bankamount.ToString();                      
        }
        else
        {
            Debug.Log("No Ghost Found");
        }       
    }
}
