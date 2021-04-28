using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompanyValuesManager : MonoBehaviour
{
    public float companyCash;
    

    public float companyReputaion;
    public int numberOfCurrentWorkers;

    [SerializeField]
    private hiredStaffLibraryScript hiredStaffLibraryScript;
    [SerializeField]
    private CompanyManager companyManager;
    [SerializeField]
    private AvailableWorkerSpawner availableWorkerSpawner;
    [SerializeField]
    private TMP_Text bankAmount;
    [SerializeField]
    private Clock clock;
    [SerializeField]
    private myCompanyExpenses expenses;

    private bool hasBeenCalculated;
    // Start is called before the first frame update
    void Start()
    {
        companyManager = GameObject.Find("CompanyManager").GetComponent<CompanyManager>();

        if (availableWorkerSpawner.isNewGame == false)
        {
            companyCash = companyManager.startingMoney;            
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCurrentWorkers = hiredStaffLibraryScript.hiredWorkers.Count;        
        if(clock.day == 1 && hasBeenCalculated == false)
        {
            float _currentCash = companyCash;
            float _newCash = _currentCash - expenses.monthlyExpenses;
            companyCash = _newCash;
            
            hasBeenCalculated = true;
        }
        if (clock.day == 2)
        {
            hasBeenCalculated = false;
        }
        bankAmount.text = companyCash + "$";
    }
}
