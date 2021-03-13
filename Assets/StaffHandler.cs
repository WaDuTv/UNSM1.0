using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffHandler : MonoBehaviour
{
    public WorkersSO worker;

    public string lastName;
    public string firstName;

    public string workerProfession;

    public int workerStatProgramming;
    public int workerStatSound;
    public int workerStatGraphics;
    public int workerStatDesign;

    // Start is called before the first frame update
    void Awake() 
    {
        lastName = worker.workerName;
        firstName = worker.workerFirstName;

        workerProfession = worker.workerProfession;

        workerStatProgramming = worker.workerStatProgramming;
        workerStatSound = worker.workerStatSound;
        workerStatGraphics = worker.workerStatGraphics;
        workerStatDesign = worker.workerStatDesign;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
