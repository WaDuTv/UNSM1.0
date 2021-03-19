using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIInputRestrictions : MonoBehaviour
{
    public TMP_InputField priceAmountInputfield;
    // Start is called before the first frame update
    void Start()
    {
        priceAmountInputfield.characterValidation = TMP_InputField.CharacterValidation.Integer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
