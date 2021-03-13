using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/ScriptableObjects/workers")]
public class WorkersSO : ScriptableObject
{
    public string workerFirstName;
    public string workerName;

    public string workerProfession;

    public int workerStatProgramming;
    public int workerStatSound;
    public int workerStatGraphics;
    public int workerStatDesign;
}
