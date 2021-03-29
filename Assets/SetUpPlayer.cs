using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpPlayer : MonoBehaviour
{
    public StaffHandler staffHandlerScript;
    public CompanyManager companyManager;
    public bool setupDone;

    [SerializeField]
    private string[] splitArray;
    // Start is called before the first frame update
    void Start()
    {
        companyManager = GameObject.Find("CompanyManager").GetComponent<CompanyManager>();
        splitArray = companyManager.playerName.Split(' ');
        string _firstName = splitArray[0];
        string _lastName = splitArray[1];
        if(setupDone == false)
        { 
            staffHandlerScript.workerStatProgramming = companyManager.playerStatProgramming;
            staffHandlerScript.workerStatSound = companyManager.playerStatSound;
            staffHandlerScript.workerStatGraphics = companyManager.playerStatGraphics;
            staffHandlerScript.workerStatDesign = companyManager.playerStatDesign;

            staffHandlerScript.lastName = _lastName;
            staffHandlerScript.firstName = _firstName;

            this.gameObject.name = "worker_" + _firstName + " " + _lastName;

            setupDone = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
