using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ShopScript : MonoBehaviour
{
    public int bankamount;
    public Button plantButton;
    public TextMeshProUGUI bankAmountText;
    public build_script buildScript;
        
    // Start is called before the first frame update
    void Start()
    {        
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
            if(EventSystem.current.currentSelectedGameObject.name == "Plant_01")
            {
                bankamount -= price;
                Debug.Log("Ich habe "+price+" vom Konto abgezogen, du hast jetzt: " + bankamount);
                bankAmountText.text = bankamount.ToString();
                buildScript.spawn_plant_01_bluerint();
            }           
        }
        else
        {
            Debug.Log("No Ghost Found");
        }
    }

}
