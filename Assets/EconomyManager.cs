using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager instance { get; private set; }

    public int totalConsumers;
    public int consumersGermany;
    public int consumersUSA;
    public int consumersRussia;

    [SerializeField]
    private Clock clock;

    private bool hasBeenUpdated;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        totalConsumers = consumersGermany + consumersRussia + consumersUSA;
    }

    // Update is called once per frame
    void Update()
    {
        if (clock.day == 1 && hasBeenUpdated == false)
        {
            totalConsumers = consumersGermany + consumersRussia + consumersUSA;
            hasBeenUpdated = true;
        }
        if(clock.day == 2 && hasBeenUpdated == true)
        {
            hasBeenUpdated = false;
        }

    }
}
