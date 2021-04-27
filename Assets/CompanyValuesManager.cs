using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyValuesManager : MonoBehaviour
{
    public float companyReputaion;
    public int numberOfCurrentWorkers;

    [SerializeField]
    private hiredStaffLibraryScript hiredStaffLibraryScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCurrentWorkers = hiredStaffLibraryScript.hiredWorkers.Count;
    }
}
