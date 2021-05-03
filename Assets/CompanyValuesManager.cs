using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

public class CompanyValuesManager : MonoBehaviour
{
    public decimal companyCash;
    [SerializeField]
    private int companyCashDisplay;
    

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
    [SerializeField]
    private playfabManager playfabManager;

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
            decimal _currentCash = (decimal)companyCash;
            decimal _newCash = _currentCash - (decimal)expenses.monthlyExpenses;
            companyCash = _newCash;
            companyCashDisplay = (int)_newCash;

            SendScoreToLeaderboard();

            hasBeenCalculated = true;
        }
        if (clock.day == 2)
        {
            hasBeenCalculated = false;
        }
        bankAmount.text = System.Math.Round(companyCash,2) + "$";
    }

     private void SendScoreToLeaderboard()
    {
        int _cash = (int)companyCash;
        playfabManager.SendCashboard(_cash);

    }
}
