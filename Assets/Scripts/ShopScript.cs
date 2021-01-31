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
    public build_script buildScript;

    //private void Awake()
    //{
    //    controls = new MouseControls();
    //}

    //private void OnEnable()
    //{
    //    controls.Enable();
    //}

    //private void OnDisable()
    //{
    //    controls.Disable();
    //}

    // Start is called before the first frame update
    void Start()
    {        
        bankAmountText.text = bankamount.ToString();
        //controls.Mouse.Click.started += _ => StartedClick();
        //controls.Mouse.Click.performed += _ => EndedClick();
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
                buildScript.spawn_plant_01_bluerint();                
                //bankamount -= price;
                //Debug.Log("Ich habe " + price + " vom Konto abgezogen, du hast jetzt: " + bankamount);
                bankAmountText.text = bankamount.ToString();
                
            }           
        }
        else
        {
            Debug.Log("No Ghost Found");
        }       
    }
}
